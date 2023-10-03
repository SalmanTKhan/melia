using System;
using Melia.Shared.L10N;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Buffs;
using Melia.Zone.Network;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Melia.Zone.World.Actors.Monsters;
using Yggdrasil.Logging;

namespace Melia.Zone.Skills.Handlers.Sorcerer
{
	/// <summary>
	/// Handler for the Sorcerer skill Summon Salamion.
	/// </summary>
	[SkillHandler(SkillId.Sorcerer_SummonSalamion)]
	public class SummonSalamion : IGroundSkillHandler
	{
		/// <summary>
		/// Handle Skill Behavior
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

			Send.ZC_SKILL_READY(caster, skill, skillHandle, caster.Position, farPos);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, 0, caster.Position, caster.Direction, Position.Zero);
			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos);

			if (caster is Character character)
			{
				var summonedMonster = new Summon(character, MonsterId.Salamion, MonsterType.Friendly);
				character.Summons.AddSummon(summonedMonster);
				summonedMonster.Name = "!@#${Auto_1}_of_{Auto_2}$*$Auto_1$*$" + caster.Name + "$*$Auto_2$*$@dicID_^*$ETC_20150317_000235$*^#@!";
				summonedMonster.Direction = caster.Direction;
				summonedMonster.OwnerHandle = caster.Handle;
				summonedMonster.Faction = FactionType.Law;
				summonedMonster.Properties.SetFloat(PropertyName.FIXMSPD_BM, 80f);
				summonedMonster.Properties.Overrides.SetFloat(PropertyName.MINPATK, 40f);
				summonedMonster.Properties.Overrides.SetFloat(PropertyName.MAXPATK, 50f);
				summonedMonster.Properties.Overrides.SetFloat(PropertyName.MINMATK, 40f);
				summonedMonster.Properties.Overrides.SetFloat(PropertyName.MAXMATK, 50f);
				summonedMonster.SetState(true);

				skillHandle = ZoneServer.Instance.World.CreateSkillHandle();
				Send.ZC_SYNC_START(caster, skillHandle, 1);
				Send.ZC_MSPD(character, summonedMonster, 0, 160f);
				summonedMonster.Components.Get<BuffComponent>()?.AddOrUpdate(new Buff(BuffId.Ability_buff_PC_Summon, 0, 0, TimeSpan.Zero, summonedMonster, summonedMonster));
				Send.ZC_SYNC_END(caster, skillHandle, 0);
				Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, skill.Data.DefaultHitDelay);
			}
		}
	}
}
