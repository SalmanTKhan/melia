using System;
using Melia.Shared.L10N;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Buffs;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Yggdrasil.Logging;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Skills.Handlers.Hoplite
{
	/// <summary>
	/// Handler for the Hoplite skill Spear Throw.
	/// </summary>
	[SkillHandler(SkillId.Hoplite_ThrouwingSpear)]
	public class SpearThrow : IGroundSkillHandler
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

			var castRange = originPos.Get2DDistance(farPos);
			if (castRange > skill.Data.MaxRange)
			{
				Log.Warning("Spear Throw: Player {0} cast skill farther than max range ({1} > {2}).", caster.Name, castRange, skill.Data.MaxRange);
				return;
			}

			var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();
			Send.ZC_SKILL_READY(caster, skill, skillHandle, originPos, farPos);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, 0, caster.Position, caster.Direction, Position.Zero);
			//caster.Components.Get<BuffComponent>()?.StartSkillBuff(BuffId.Skill_MomentaryBlock_Buff, caster, skill, TimeSpan.FromSeconds(1));

			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos);
			Send.ZC_MOVE_STOP(caster, originPos);
			if (caster is Character character)
				Send.ZC_NORMAL.Skill_1A9(caster, "warrior_f_", character.Inventory.GetItem(EquipSlot.RightHand).Id);
			Send.ZC_NORMAL.Skill_ItemToss(caster, "warrior_f_", "RH", farPos, "F_smoke177", 3, 0.2f, 0, 600, 1, 230, 290);

			var radius = (int)skill.Data.SplashRange * 2;
			var targets = caster.Map.GetAttackableEntitiesInRange(caster, farPos, radius);

			foreach (var currentTarget in targets.LimitBySDR(caster, skill))
			{
				var forceId = ForceId.GetNew();
				var skillHitResult = SCR_SkillHit(caster, currentTarget, skill);
				currentTarget.TakeDamage(skillHitResult.Damage, caster);

				currentTarget.Components.Get<BuffComponent>()?.AddOrUpdate(new Buff(BuffId.Common_Shock, 0, 0, TimeSpan.FromSeconds(5), currentTarget, caster));

				var hitInfo = new HitInfo(caster, currentTarget, skill, skillHitResult.Damage, skillHitResult.Result);
				hitInfo.ForceId = forceId;

				Send.ZC_HIT_INFO(caster, currentTarget, hitInfo);
			}
		}
	}
}
