using System.Collections.Generic;
using System;
using Melia.Shared.Game.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Monsters;
using Yggdrasil.Logging;
using static Melia.Zone.Skills.SkillUseFunctions;
using Melia.Shared.L10N;
using Melia.Zone.World.Actors.CombatEntities.Components;

namespace Melia.Zone.Skills.Handlers.Peltasta
{
	/// <summary>
	/// Handler for the Peltasta skill Shield Lob.
	/// </summary>
	[SkillHandler(SkillId.Peltasta_ShieldLob)]
	public class ShieldLob : IGroundSkillHandler
	{
		/// <summary>
		/// Handles skill behavior
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		/// <param name="originPos"></param>
		/// <param name="farPos"></param>
		/// <param name="designatedTarget"></param>
		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, ICombatEntity designatedTarget)
		{
			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			skill.IncreaseOverheat();
			caster.TurnTowards(designatedTarget);
			caster.SetAttackState(true);

			var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();

			Send.ZC_SKILL_READY(caster, skill, skillHandle, originPos, farPos);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, 0, caster.Position, caster.Direction, Position.Zero);
			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos);
			Send.ZC_NORMAL.SkillPad(caster, skill, "Peltasta_ShieldLob", originPos, caster.Direction, -0.7853982f, 0, skillHandle, 30);

			var shieldMonster = new Mob(57001, MonsterType.NPC);
			shieldMonster.Name = "pad_attach_object33";
			shieldMonster.AssociatedHandle = shieldMonster.Handle;
			shieldMonster.Position = originPos;
			shieldMonster.Direction = caster.Direction;
			shieldMonster.Faction = FactionType.Neutral;
			shieldMonster.Properties.SetFloat(PropertyName.Range, 0);
			shieldMonster.Properties.SetFloat(PropertyName.Scale, 0.41f);
			shieldMonster.Died += (killer, killed) =>
			{
				Send.ZC_NORMAL.SkillPad(caster, skill, "Peltasta_ShieldLob2", originPos, caster.Direction, 0, 145.8735f, skillHandle, 30, false);
			};

			caster.Map.AddMonster(shieldMonster);

			if (caster is Character character)
				Send.ZC_NORMAL.Skill_1A9(caster, "warrior_f_", character.Inventory.GetItem(EquipSlot.RightHand).Id);
			Send.ZC_NORMAL.Skill_88(shieldMonster);
			//Send.ZC_NORMAL.AttachEffect(shieldMonster, AnimationName.VioletLight, 1, HeightOffset.BOT, 0, 0, 0, 2.606323f);
			Send.ZC_NORMAL.AttachEffect(shieldMonster, AnimationName.VioletLight, 1, HeightOffset.BOT);
			Send.ZC_NORMAL.Skill_SetActorHeight(shieldMonster, skillHandle, 22);
			Send.ZC_NORMAL.Skill_EffectMovement(caster, skillHandle, farPos - originPos, 200);

			var radius = (int)skill.Data.SplashRange * 2;
			var targets = caster.Map.GetAttackableEntitiesInRange(caster, farPos, radius);
			var damageDelay = TimeSpan.FromMilliseconds(200);

			var hits = new List<SkillHitInfo>();

			foreach (var currentTarget in targets.LimitBySDR(caster, skill))
			{
				var skillHitResult = SCR_SkillHit(caster, currentTarget, skill);
				if (currentTarget.TakeDamage(skillHitResult.Damage, caster))
					Send.ZC_SKILL_CAST_CANCEL(caster);

				var skillHit = new SkillHitInfo(caster, currentTarget, skill, skillHitResult, damageDelay, TimeSpan.Zero);
				hits.Add(skillHit);
			}

			Send.ZC_SKILL_HIT_INFO(caster, hits);
			Send.ZC_NORMAL.Skill_45(caster);
		}
	}
}
