using System;
using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Melia.Zone.Buffs;
using Melia.Shared.L10N;

namespace Melia.Zone.Skills.Handlers.Hunter
{
	/// <summary>
	/// Handler for the Hunter skill Coursing.
	/// </summary>
	[SkillHandler(SkillId.Hunter_Coursing)]
	public class Coursing : IGroundSkillHandler
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
			if (caster is Character character)
			{
				var companion = character.ActiveCompanion;
				if (companion == null)
				{
					character.SystemMessage("CompanionIsNotActive");
					Send.ZC_SKILL_DISABLE(caster);
					return;
				}

				var maxRange = skill.Properties.GetFloat(PropertyName.MaxR);
				if (!caster.Position.InRange2D(farPos, maxRange))
				{
					caster.ServerMessage(Localization.Get("Too far away."));
					return;
				}

				if (!caster.TrySpendSp(skill))
				{
					caster.ServerMessage(Localization.Get("Not enough SP."));
					return;
				}

				skill.IncreaseOverheat();
				caster.TurnTowards(target);
				caster.SetAttackState(true);

				var radius = (float)farPos.Get2DDistance(originPos);
				Send.ZC_NORMAL.UpdateSkillEffect(caster, 0, caster.Position, caster.Direction, Position.Zero);
				Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos);

				if (target != null)
				{
					var timeRequired = companion.Components.Get<MovementComponent>().MoveTo(target.Position.GetRandomInRange2D(5, 7));
					Task.Delay(timeRequired)
						.ContinueWith(_ =>
						{
							var coursingDamageDebuff = new Buff(BuffId.Coursing_Damage_Debuff, 0, 0, TimeSpan.FromSeconds(5), target, companion);
							var decreaseHealDebuff = new Buff(BuffId.DecreaseHeal_Debuff, 0, 0, TimeSpan.FromSeconds(5), target, companion);
							var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();
							Send.ZC_SYNC_START(caster, skillHandle, 1);
							target.Components.Get<BuffComponent>()?.AddOrUpdate(coursingDamageDebuff, decreaseHealDebuff);
							Send.ZC_SYNC_END(caster, skillHandle, 0);
							Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, TimeSpan.FromMilliseconds(200));
						}).Start();
				}
			}
		}
	}
}
