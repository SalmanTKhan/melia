using System;
using Melia.Shared.L10N;
using Melia.Shared.Game.Const;
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
	/// Handler for the Sorcerer skill Summon Familiar.
	/// </summary>
	[SkillHandler(SkillId.Sorcerer_SummonFamiliar)]
	public class SummonFamiliar : IGroundSkillHandler
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
			Send.ZC_SYNC_START(caster, skillHandle, 1);
			Send.ZC_SYNC_END(caster, skillHandle, 0);
			Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, skill.Data.DefaultHitDelay);

			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos);

			if (caster is Character character)
			{
				for (var i = 0; i < 5; i++)
				{
					var summon = new Summon(character, MonsterId.Familiar, MonsterType.Friendly);
					character.Summons.AddSummon(summon);
					summon.Map = caster.Map;
					summon.Direction = caster.Direction;
					summon.Faction = FactionType.Law;
					summon.Properties.SetFloat(PropertyName.FIXMSPD_BM, 80f);
					summon.SetState(true);

					skillHandle = ZoneServer.Instance.World.CreateSkillHandle();
					Send.ZC_SYNC_START(caster, skillHandle, 1);
					Send.ZC_MSPD(character, summon, 0, summon.Properties.GetFloat(PropertyName.MSPD));
					summon.Components.Get<BuffComponent>()?.AddOrUpdate(new Buff(BuffId.Ability_buff_PC_Summon, 0, 0, TimeSpan.Zero, summon, summon));
					Send.ZC_SYNC_END(caster, skillHandle, 0);
					Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, skill.Data.DefaultHitDelay);
				}
				caster.Components.Get<BuffComponent>()?.AddOrUpdate(new Buff(BuffId.sorcerer_bat, 0, 0, TimeSpan.FromSeconds(60), caster, caster));
			}
		}
	}
}
