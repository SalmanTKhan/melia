using System;
using System.Collections.Generic;
using Melia.Shared.L10N;
using Melia.Shared.Game.Const;
using Melia.Shared.World;
using Melia.Zone.Buffs;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Yggdrasil.Logging;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Skills.Handlers.Peltasta
{
	/// <summary>
	/// Handler for the Peltasta skill Swash Buckling.
	/// </summary>
	[SkillHandler(SkillId.Peltasta_SwashBuckling)]
	public class SwashBuckling : IGroundSkillHandler
	{
		/// <summary>
		/// Handles skill behavior
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		/// <param name="originPos"></param>
		/// <param name="farPos"></param>
		/// <param name="target"></param>
		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, ICombatEntity target)
		{
			var castRange = originPos.Get2DDistance(farPos);
			if (castRange > skill.Data.MaxRange)
			{
				Log.Warning("Swash Buckling: Player {0} cast skill farther than max range ({1} > {2}).", caster.Name, castRange, skill.Data.MaxRange);
				Send.ZC_SKILL_CAST_CANCEL(caster);
				return;
			}

			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			skill.IncreaseOverheat();
			var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();
			Send.ZC_SKILL_READY(caster, skill, skillHandle, caster.Position, farPos);

			Send.ZC_NORMAL.UpdateSkillEffect(caster, caster.Handle, caster.Position, caster.Direction, caster.Position);

			var targets = caster.Map.GetAttackableEntitiesInRange(caster, farPos, (int)skill.Data.SplashRange * 4);
			var damageDelay = TimeSpan.FromMilliseconds(200);

			var hits = new List<SkillHitInfo>();

			foreach (var currentTarget in targets.LimitBySDR(caster, skill))
			{
				var skillHitResult = SCR_SkillHit(caster, currentTarget, skill);
				currentTarget.TakeDamage(skillHitResult.Damage, caster);

				var skillHit = new SkillHitInfo(caster, currentTarget, skill, skillHitResult, damageDelay, TimeSpan.Zero);
				hits.Add(skillHit);
			}

			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos, hits);

			foreach (var currentTarget in targets.LimitBySDR(caster, skill))
			{
				var buff = new Buff(BuffId.ProvocationImmunity_Debuff, 0, 0, TimeSpan.FromSeconds(5 + 2 * skill.Level), currentTarget, caster);
				//buff.Skill = skill;
				Send.ZC_NORMAL.PlayTextEffect(currentTarget, caster, AnimationName.ShowBuffText, 80);
				Send.ZC_NORMAL.SetActorColor(currentTarget, 150, 160, 255, 255, 1.5f, 1);
				Send.ZC_SYNC_START(caster, skillHandle, 1);
				currentTarget.Components.Get<BuffComponent>()?.AddOrUpdate(buff);
				Send.ZC_SYNC_END(caster, skillHandle, 0);
				Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, TimeSpan.FromMilliseconds(100));
			}
		}
	}
}
