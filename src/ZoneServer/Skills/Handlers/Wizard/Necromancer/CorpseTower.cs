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
using Melia.Zone.World.Actors.Monsters;
using Yggdrasil.Util;

namespace Melia.Zone.Skills.Handlers.Necromancer
{
	/// <summary>
	/// Handler for the Necromancer skill Corpse Tower.
	/// </summary>
	[SkillHandler(SkillId.Necromancer_CorpseTower)]
	public class CorpseTower : IGroundSkillHandler
	{
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
				var summon = new Summon(character, MonsterId.SkeletonSoldier, MonsterType.Friendly);
				character.Summons.AddSummon(summon);
				summon.Name = "!@#${Auto_1}_of_{Auto_2}$*$Auto_1$*$" + caster.Name + "$*$Auto_2$*$@dicID_^*$ETC_20150918_014215$*^#@!";
				summon.Faction = FactionType.Law;
				summon.Tendency = TendencyType.Aggressive;
				summon.FromGround = true;
				summon.Properties.SetFloat(PropertyName.Level, caster.Level);
				summon.Properties.SetFloat(PropertyName.Lv, caster.Level);
				summon.Properties.SetFloat(PropertyName.FIXMSPD_BM, 140f);

				var attack = RandomProvider.Get().Next((int)caster.Properties.GetFloat(PropertyName.MINMATK),
					(int)caster.Properties.GetFloat(PropertyName.MINMATK))
					* (-0.01f + (.173f * skill.Level));
				var life = 40f;
				var defense = 99999999f;

				summon.Properties.SetFloat(PropertyName.FixedAttack, attack);
				summon.Properties.SetFloat(PropertyName.FixedLife, life);
				summon.Properties.SetFloat(PropertyName.FixedDefence, defense);
				summon.Properties.InvalidateAll();
				summon.Components.Add(new LifeTimeComponent(summon, TimeSpan.FromSeconds(100)));
				summon.SetState(true);
				Send.ZC_NORMAL.SetInvisible(summon, 0);
				Send.ZC_NORMAL.Skill_Unknown_C6(summon, 1);

				skillHandle = ZoneServer.Instance.World.CreateSkillHandle();
				Send.ZC_SYNC_START(caster, skillHandle, 1);
				summon.Components.Get<BuffComponent>()?.AddOrUpdate(new Buff(BuffId.Ability_buff_PC_Summon, 0, 0, TimeSpan.Zero, summon, summon));
				Send.ZC_SYNC_END(caster, skillHandle, 0);
				Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, skill.Data.DefaultHitDelay);
			}
		}
	}
}
