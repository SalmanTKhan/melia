using System;
using System.Collections.Generic;
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

namespace Melia.Zone.Skills.Handlers.BlossomBlader
{
	/// <summary>
	/// Handler for the BlossomBlader skill Fallen Blossom.
	/// </summary>
	[SkillHandler(SkillId.BlossomBlader_FallenBlossom)]
	public class FallenBlossom : IMeleeGroundSkillHandler, IDynamicCasted
	{
		public void StartDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			// Not sure if this is needed, since it sends no packetstring for sound
			if (caster is Character character)
			{
				Send.ZC_PLAY_SOUND(character, 0);
				Send.ZC_NORMAL.Skill_DynamicCastStart(character, skill.Id);
			}
		}

		public void EndDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (caster is Character character)
				Send.ZC_NORMAL.Skill_DynamicCastEnd(character, skill.Id, 2);
		}

		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, IList<ICombatEntity> targets)
		{
			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			skill.IncreaseOverheat();
			caster.TurnTowards(farPos);
			caster.SetAttackState(true);

			var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();

			Send.ZC_SKILL_READY(caster, skill, skillHandle, caster.Position, farPos);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, 0, caster.Position, caster.Direction, Position.Zero);

			var noDamageBuff = new Buff(BuffId.Skill_NoDamage_Buff, 0, 0, TimeSpan.FromSeconds(1.2), caster, caster);
			var blossomPVPBuff = new Buff(BuffId.BlossomSlash_PVP_Buff, 0, 0, TimeSpan.FromSeconds(1.5), caster, caster);

			Send.ZC_SYNC_START(caster, skillHandle, 1);

			caster.Components.Get<BuffComponent>()?.AddOrUpdate(noDamageBuff);
			caster.Components.Get<BuffComponent>()?.AddOrUpdate(blossomPVPBuff);

			Send.ZC_SYNC_END(caster, skillHandle, 0);
			Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, TimeSpan.FromMilliseconds(300));
			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos);

			foreach (var target in targets)
			{
				var controlBladeDebuff = new Buff(BuffId.ControlBlade_Debuff, 0, 0, TimeSpan.FromSeconds(3), target, caster);
				//controlBladeDebuff.Skill = skill;
				var floweringDebuff = new Buff(BuffId.Flowering_Debuff, 0, 0, TimeSpan.FromSeconds(30), target, caster);
				//floweringDebuff.Skill = skill;
				target.Components.Get<BuffComponent>()?.AddOrUpdate(controlBladeDebuff, floweringDebuff);
			}
		}
	}
}
