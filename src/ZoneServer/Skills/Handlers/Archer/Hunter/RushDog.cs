using System;
using System.Threading.Tasks;
using Melia.Shared.L10N;
using Melia.Shared.Game.Const;
using Melia.Shared.World;
using Melia.Zone.Buffs;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Yggdrasil.Util;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Skills.Handlers.Hunter
{
	/// <summary>
	/// Handler for the Hunter skill Rush Dog.
	/// </summary>
	[SkillHandler(SkillId.Hunter_RushDog)]
	public class RushDog : IGroundSkillHandler, IDynamicCasted
	{
		public void StartDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (caster is Character character)
				Send.ZC_NORMAL.Skill_DynamicCastStart(character, skill.Id);
		}

		public void EndDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (caster is Character character)
				Send.ZC_NORMAL.Skill_DynamicCastEnd(character, skill.Id, maxCastTime);
		}

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

				if (!caster.TrySpendSp(skill))
				{
					caster.ServerMessage(Localization.Get("Not enough SP."));
					return;
				}

				skill.IncreaseOverheat();
				caster.SetAttackState(true);

				var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();
				Send.ZC_SKILL_READY(caster, skill, skillHandle, caster.Position, farPos);

				var radius = (float)farPos.Get2DDistance(originPos);
				Send.ZC_NORMAL.UpdateSkillEffect(caster, target?.Handle ?? 0, originPos, originPos.GetDirection(farPos), target?.Position ?? Position.Zero);
				Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos);

				if (target != null)
				{
					var timeRequired = companion.Components.Get<MovementComponent>().MoveTo(target.Position.GetRandomInRange2D(7, 10));
					Task.Delay(timeRequired)
						.ContinueWith(_ =>
						{
							var random = RandomProvider.Get();
							// 50% Chance of Rush Dog's Stun occurring
							if (random.NextDouble() >= .5)
							{
								var stun = new Buff(BuffId.Stun, 0, 0, TimeSpan.FromSeconds(4), target, caster);
								Send.ZC_NORMAL.PlayTextEffect(target, caster, AnimationName.ShowBuffText, 61);
								Send.ZC_SYNC_START(caster, skillHandle, 1);
								target.Components.Get<BuffComponent>()?.AddOrUpdate(stun);
								Send.ZC_SYNC_END(caster, skillHandle, 0);
								Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, TimeSpan.FromMilliseconds(100));
							}

							var forceId = ForceId.GetNew();
							var skillHitResult = SCR_SkillHit(caster, target, skill);

							target.TakeDamage(skillHitResult.Damage, caster);

							var hitInfo = new HitInfo(companion, target, skill, skillHitResult.Damage, skillHitResult.Result);
							hitInfo.ForceId = forceId;
							hitInfo.HitCount = 5;

							Send.ZC_HIT_INFO(companion, target, hitInfo);
						});
				}
			}
		}
	}
}
