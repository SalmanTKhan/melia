using System;
using Melia.Shared.L10N;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Buffs;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Yggdrasil.Logging;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Skills.Handlers.Doppelsoeldner
{
	/// <summary>
	/// Handler for the Doppelsoeldner skill Punish.
	/// </summary>
	[SkillHandler(SkillId.Doppelsoeldner_Punish)]
	public class Punish : IGroundSkillHandler
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
			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			skill.IncreaseOverheat();
			caster.SetAttackState(true);

			// Not actually skill handle but not to sure what to use here for skill ready
			var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();
			Send.ZC_SKILL_READY(caster, skill, skillHandle, originPos, farPos);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, 0, caster.Position, caster.Direction, Position.Zero);

			if (target == null)
			{
				Send.ZC_SKILL_DISABLE(caster);
				return;
			}

			Send.ZC_SYNC_START(caster, skillHandle, 1);
			caster.Position = target.Position.GetRandomInRange2D(5, 10);
			Send.ZC_SET_POS(caster);
			Send.ZC_ROTATE(caster);
			Send.ZC_SYNC_END(caster, skillHandle, 0);
			Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, TimeSpan.FromMilliseconds(200));
			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos);

			target.StartBuff(BuffId.DecreaseHeal_Debuff, 0, 0, TimeSpan.FromSeconds(5), caster);

			var skillHitResult = SCR_SkillHit(caster, target, skill);
			target.TakeDamage(skillHitResult.Damage, caster);

			var forceId = ForceId.GetNew();
			var hitInfo = new HitInfo(caster, target, skill, skillHitResult.Damage, skillHitResult.Result);
			hitInfo.ForceId = forceId;

			Send.ZC_HIT_INFO(caster, target, hitInfo);
		}
	}
}
