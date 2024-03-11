using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Melia.Shared.L10N;
using Melia.Shared.Game.Const;
using Melia.Shared.World;
using Melia.Zone.Buffs;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.CombatEntities.Components;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Skills.Handlers.Necromancer
{
	/// <summary>
	/// Handler for the Necromancer skill Flesh Cannon.
	/// </summary>
	[SkillHandler(SkillId.Necromancer_FleshCannon)]
	public class FleshCannon : IGroundSkillHandler
	{
		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, ICombatEntity target)
		{
			if (!skill.Vars.TryGet<Position>("Melia.ToolGroundPos", out var targetPos))
			{
				caster.ServerMessage(Localization.Get("No target location specified."));
				return;
			}

			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			skill.IncreaseOverheat();
			var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();

			Send.ZC_SKILL_READY(caster, skill, skillHandle, caster.Position, targetPos);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, caster.Handle, caster.Position, caster.Direction, caster.Position);

			var effectHandle = ZoneServer.Instance.World.CreateEffectHandle();

			Send.ZC_NORMAL.PlayCorpsePartsRing(caster, effectHandle, 0.25f, 20, 15, 9, 400981);

			var targets = caster.Map.GetAttackableEntitiesInRange(caster, targetPos, (int)skill.Data.SplashRange * 4);
			var damageDelay = TimeSpan.FromMilliseconds(200);

			var hits = new List<SkillHitInfo>();

			foreach (var currentTarget in targets.LimitBySDR(caster, skill))
			{
				var skillHitResult = SCR_SkillHit(caster, currentTarget, skill);
				currentTarget.TakeDamage(skillHitResult.Damage, caster);

				var skillHit = new SkillHitInfo(caster, currentTarget, skill, skillHitResult, damageDelay, TimeSpan.Zero);
				hits.Add(skillHit);
			}

			Send.ZC_SKILL_MELEE_GROUND(caster, skill, targetPos, hits);

			foreach (var currentTarget in targets.LimitBySDR(caster, skill))
			{
				var buff = new Buff(BuffId.FirePillar_Debuff, 0, 0, TimeSpan.FromSeconds(10), currentTarget, caster);
				//buff.Skill = skill;
				Send.ZC_SYNC_START(caster, skillHandle, 1);
				currentTarget.Components.Get<BuffComponent>()?.AddOrUpdate(buff);
				Send.ZC_SYNC_END(caster, skillHandle, 0);
				Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, TimeSpan.FromMilliseconds(400));
			}
			Task.Delay(TimeSpan.FromSeconds(10)).ContinueWith(_ => Send.ZC_NORMAL.SkillPad(caster, skill, "Wizard_New_FirePillar10", targetPos, caster.Direction, -0.2594702f, 62.63292f, skillHandle, 50, false));
		}
	}
}
