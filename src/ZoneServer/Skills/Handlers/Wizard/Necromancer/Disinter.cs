using System;
using Melia.Shared.Game.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Shared.L10N;

namespace Melia.Zone.Skills.Handlers.Necromancer
{
	/// <summary>
	/// Handler for the Necromancer skill Disinter.
	/// </summary>
	[SkillHandler(SkillId.Necromancer_Disinter)]
	public class Disinter : IGroundSkillHandler
	{
		/// <summary>
		/// Handles the skill, buffing summons in target area.
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
			caster.SetAttackState(true);

			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos);

			if (caster is Character character && character.Summons.TryGetSummon(designatedTarget.Handle, out var victimizedSummon))
			{
				designatedTarget.Kill(null);

				var buffId = BuffId.Disinter_Soldier_Buff;
				switch (victimizedSummon.Id)
				{
					case MonsterId.SkeletonArcher:
						buffId = BuffId.Disinter_Archer_Buff;
						break;
					case MonsterId.SkeletonSoldier:
						buffId = BuffId.Disinter_Soldier_Buff;
						break;
					case MonsterId.SkeletonMage:
						buffId = BuffId.Disinter_Wizard_Buff;
						break;
				}

				var skeletonSummons = character.Summons.GetSummons(s => s.Id == MonsterId.SkeletonSoldier || s.Id == MonsterId.SkeletonArcher || s.Id == MonsterId.SkeletonMage);
				foreach (var summon in skeletonSummons)
				{
					summon.StartBuff(buffId, skill.Level, 0, TimeSpan.FromSeconds(30), caster);
				}

				caster.StartBuff(BuffId.Disinter_PC_Buff, TimeSpan.FromSeconds(30), caster);
			}
		}
	}
}
