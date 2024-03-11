using System;
using Melia.Shared.L10N;
using Melia.Shared.Game.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.Skills.Combat;
using static Melia.Zone.Skills.SkillUseFunctions;
using System.Collections.Generic;
using Melia.Zone.Skills.SplashAreas;

namespace Melia.Zone.Skills.Handlers.Necromancer
{
	/// <summary>
	/// Handler for the Necromancer skill Gather Corpse.
	/// </summary>
	[SkillHandler(SkillId.Necromancer_GatherCorpse)]
	public class GatherCorpse : ITargetSkillHandler
	{
		public void Handle(Skill skill, ICombatEntity caster, ICombatEntity designatedTarget)
		{
			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			skill.IncreaseOverheat();
			caster.TurnTowards(designatedTarget);
			caster.SetAttackState(true);

			Send.ZC_SKILL_READY(caster, skill, designatedTarget.Position, Position.Zero);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, designatedTarget.Handle, caster.Position, designatedTarget.Direction, Position.Zero);

			if (designatedTarget == null)
			{
				Send.ZC_SKILL_FORCE_TARGET(caster, null, skill);
				return;
			}

			var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();
			var damageDelay = TimeSpan.Zero;
			var skillHitDelay = skill.Properties.HitDelay;

			var splashArea = new Circle(designatedTarget.Position, skill.Properties.GetFloat(PropertyName.SplRange));
			var targets = caster.Map.GetAttackableEntitiesIn(caster, splashArea);

			var skillHits = new List<SkillHitInfo>();

			foreach (var target in targets.LimitBySDR(caster, skill))
			{
				var skillHitResult = SCR_SkillHit(caster, target, skill);
				target.TakeDamage(skillHitResult.Damage, caster);

				var skillHit = new SkillHitInfo(caster, target, skill, skillHitResult, damageDelay, skillHitDelay);
				skillHit.ForceId = ForceId.GetNew();

				Send.ZC_SYNC_START(caster, skillHandle, 1);
				target.StartBuff(BuffId.NecromancerPoison_Debuff, TimeSpan.FromSeconds(20), caster);
				target.StartBuff(BuffId.GatherCorpse_Debuff, TimeSpan.FromSeconds(6), caster);
				Send.ZC_SYNC_END(caster, skillHandle, 0.1f);
				Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, skill.Data.DefaultHitDelay);

				skillHits.Add(skillHit);
			}

			Send.ZC_SKILL_FORCE_TARGET(caster, designatedTarget, skill, skillHits);

			Send.ZC_NORMAL.Skill_45(caster);
			Send.ZC_NORMAL.SkillCancel(caster, skill.Id);
			Send.ZC_NORMAL.SetSkill_7B(caster, skill.Id);

		}
	}
}
