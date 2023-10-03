using System;
using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors;
using Yggdrasil.Logging;
using Melia.Zone.World.Actors.Monsters;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Melia.Zone.World.Actors.Characters.Components;
using Melia.Zone.Buffs;
using Melia.Shared.L10N;

namespace Melia.Zone.Skills.Handlers.Cryomancer
{
	/// <summary>
	/// Handler for the Cryomancer skill Snow Rolling.
	/// </summary>
	[SkillHandler(SkillId.Cryomancer_SnowRolling)]
	public class SnowRolling : IDynamicGroundSkillHandler
	{
		public void StartDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (caster is Character character)
			{
				Send.ZC_PLAY_SOUND(character, character.Gender == Gender.Male ? "voice_wiz_m_snowrolling_shot" : "voice_wiz_snowrolling_shot");
				Send.ZC_NORMAL.Skill_DynamicCastStart(character, skill.Id);
			}
		}

		public void EndDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (caster is Character character)
			{
				Send.ZC_STOP_SOUND(character, character.Gender == Gender.Male ? "voice_wiz_m_snowrolling_shot" : "voice_wiz_snowrolling_shot");
				Send.ZC_NORMAL.Skill_DynamicCastEnd(character, skill.Id, 1);
			}
		}

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

			Send.ZC_SKILL_READY(caster, skill, skillHandle, caster.Position, farPos);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, caster.Handle, caster.Position, caster.Direction, caster.Position);

			if (caster is Character character)
				character.Components.Get<SkillComponent>()?.AddSilent(new Skill(character, SkillId.Common_StateClear, 1));
			Send.ZC_NORMAL.ApplyBuff(caster, "SnowRolling_Buff", SkillId.Common_StateClear, 1);

			var snowball = new Mob(47312, MonsterType.Friendly);
			snowball.Faction = FactionType.Law;
			snowball.Position = (originPos + new Position(0, -0.10f, 0)).Floor;
			snowball.Components.Add(new LifeTimeComponent(snowball, TimeSpan.FromSeconds(4)));
			snowball.OwnerHandle = caster.Handle;
			snowball.AssociatedHandle = caster.Handle;
			snowball.Died += Snowball_Died;
			caster.Map.AddMonster(snowball);

			//Send.ZC_NORMAL.AttachEffect(snowball, null, 1, HeightOffset.BOT, 0, 10, 0, 2.605713f);
			Send.ZC_NORMAL.AttachEffect(snowball, null, 1, HeightOffset.BOT, 0, 10, 0);
			Send.ZC_NORMAL.PetBuff(caster, snowball, 1, 1, 1, "SnowRolling_Buff", 0);
			// Clear All Effects
			Send.ZC_NORMAL.Skill_CallLuaFunc(snowball, AnimationName.MissileDead, 2, 4, 0, 3, 1);
			Send.ZC_MOVE_ANIM(snowball, FixedAnimation.WLK, 0);
			Send.ZC_STD_ANIM(snowball, FixedAnimation.WLK);
			Send.ZC_NORMAL.SetScale(snowball, "F_wizard_snowrolling_ground", 0.65f);
			Send.ZC_NORMAL.SetInvisible(snowball);
			Send.ZC_NORMAL.Skill_Unknown_C6(snowball);
			Send.ZC_NORMAL.Skill_OffsetY(snowball, 10.4f);
			Send.ZC_ATTACH_TO_OBJ(caster, snowball, AnimationName.DummyTop, 0, 0.001f);
			Send.ZC_NORMAL.PlayEffect(caster, 0, "BOT", 0, 0, AnimationName.Empty);
			Send.ZC_GROUND_EFFECT(caster, AnimationName.Empty, snowball.Position);

			var buff = new Buff(BuffId.SnowRolling_Buff, 0, 0, TimeSpan.FromSeconds(10000), caster, caster);
			Send.ZC_SYNC_START(caster, skillHandle, 1);
			caster.Components.Get<BuffComponent>()?.AddOrUpdate(buff);
			Send.ZC_SYNC_END(caster, skillHandle, 0);
			Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, TimeSpan.FromMilliseconds(300));

			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos, null);
		}

		private void Snowball_Died(ICombatEntity killer, ICombatEntity killed)
		{
			if (killed is Mob snowball)
			{
				// This component still runs added a dead check within it for it to stop repeating itself.
				snowball.Components.Remove<LifeTimeComponent>();
				if (snowball.Map.TryGetCharacter(snowball.OwnerHandle, out var owner))
				{
					Task.Delay(2500).ContinueWith(_ =>
					{
						owner.Skills.RemoveSilent(SkillId.Common_StateClear);
						Send.ZC_NORMAL.RemoveBuff(owner, "SnowRolling_Buff");
						Send.ZC_SKILL_DISABLE(owner, -512);
						Send.ZC_NORMAL.PlayEffect(snowball, 0, "BOT", 0, 0, AnimationName.Empty, 0, owner.Handle);
						Send.ZC_ATTACH_TO_OBJ(owner, null, 0, 0, 1, 0, 0, 0, 0, 0);
						owner.Buffs.Remove(BuffId.SnowRolling_Buff);
						Send.ZC_NORMAL.SetSkill_7B(owner, SkillId.Cryomancer_SnowRolling);
						Send.ZC_NORMAL.ClearEffects(snowball);
						Send.ZC_EXEC_CLIENT_SCP(owner.Connection, @"UPDATE_PC_FOLLOWER_LIST("")");
					});
				}
			}
		}
	}
}
