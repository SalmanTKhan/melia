using System;
using System.Threading.Tasks;
using Melia.Shared.Game.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Melia.Zone.Buffs;
using Melia.Shared.L10N;
using Melia.Zone.Skills.Combat;
using Melia.Zone.World.Actors.Monsters;

namespace Melia.Zone.Skills.Handlers.Bokor
{
	/// <summary>
	/// Handler for the Bokor skill Zombify.
	/// </summary>
	[SkillHandler(SkillId.Bokor_Zombify)]
	public class Zombify : IGroundSkillHandler
	{
		/// <summary>
		/// Handles skill, applying a buff to the caster.
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		/// <param name="originPos"></param>
		/// <param name="dir"></param>
		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, ICombatEntity target)
		{
			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			skill.IncreaseOverheat();
			caster.SetAttackState(true);
			Send.ZC_NORMAL.Skill_Unknown_D4(caster);


			var forceId = ForceId.GetNew();
			Send.ZC_SKILL_FORCE_GROUND(caster, skill, farPos, forceId, null);

			if (caster is Character character)
			{
				var summon = new Summon(character, MonsterId.Zombie, MonsterType.Friendly);
				character.Summons.AddSummon(summon);
				summon.Map = caster.Map;
				summon.Faction = FactionType.Neutral;
				summon.FromGround = true;
				summon.Components.Add(new LifeTimeComponent(summon, TimeSpan.FromSeconds(10 + 2 * skill.Level)));
				summon.SetState(true, false, false);
				summon.TurnTowards(caster);

				var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();
				Send.ZC_SYNC_START(caster, skillHandle, 1);
				summon.StartBuff(BuffId.Ability_buff_PC_Zombie, 0, 0, TimeSpan.Zero, summon);
				Send.ZC_SYNC_END(caster, skillHandle, 0);
				Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, skill.Data.DefaultHitDelay);
			}
		}
	}
}
