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
using Yggdrasil.Logging;

namespace Melia.Zone.Skills.Handlers.Lama
{
	/// <summary>
	/// Handler for the Lama skill Lamapose.
	/// </summary>
	[SkillHandler(SkillId.Lama_Lamapose)]
	public class Lamapose : IGroundSkillHandler
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
			if (caster is Character character)
			{
				Send.ZC_SKILL_READY(caster, skill, 1, caster.Position, farPos);
				Send.ZC_NORMAL.UpdateSkillEffect(caster, caster.Handle, caster.Position, caster.Direction, caster.Position);
				Send.ZC_SYNC_START(caster, skillHandle, 1);

				if (!character.Buffs.Has(BuffId.Lamapose_Buff))
				{
					Send.ZC_NORMAL.SetMainAttackSkill(character, SkillId.Lama_Fist);
					Send.ZC_NORMAL.SetSubAttackSkill(character, SkillId.Lama_Kick);
					var buff = new Buff(BuffId.Lamapose_Buff, 0, 0, TimeSpan.FromMilliseconds(200), caster, caster);
					//buff.Skill = skill;
					character.Buffs.AddOrUpdate(buff);
				}
				else
				{
					Send.ZC_NORMAL.SetMainAttackSkill(character, SkillId.None);
					Send.ZC_NORMAL.SetSubAttackSkill(character, SkillId.None);
					character.Buffs.Remove(BuffId.Lamapose_Buff);
				}
				Send.ZC_SYNC_END(caster, skillHandle, 0);
				Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, TimeSpan.FromMilliseconds(100));
			}

			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos);
		}
	}
}
