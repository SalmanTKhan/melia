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

namespace Melia.Zone.Skills.Handlers.Barbarian
{
	/// <summary>
	/// Handler for the Barbarian skill Warcry.
	/// </summary>
	[SkillHandler(SkillId.Barbarian_Warcry)]
	public class Warcry : ISelfSkillHandler
	{
		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Direction direction)
		{
			var castRange = caster.Position.Get2DDistance(originPos);
			if (castRange > skill.Data.MaxRange)
			{
				Log.Warning("Warcry: Player {0} cast skill farther than max range ({1} > {2}).", caster.Name, castRange, skill.Data.MaxRange);
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
			Send.ZC_SKILL_READY(caster, skill, skillHandle, caster.Position, caster.Position);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, caster.Handle, caster.Position, caster.Direction, caster.Position);

			Send.ZC_SYNC_START(caster, skillHandle, 1);
			if (caster is Character character)
				Send.ZC_PLAY_SOUND(character, "skl_eff_warcry_up");
			var targets = caster.Map.GetAttackableEntitiesInRange(caster, originPos, (int)skill.Data.SplashRange * 2);

			foreach (var target in targets)
			{
				var warcryDebuff = new Buff(BuffId.Warcry_Debuff, 0, 0, TimeSpan.FromSeconds(10), target, caster);
				//warcryDebuff.Skill = skill;
				target.Components.Get<BuffComponent>()?.AddOrUpdate(warcryDebuff);
			}
			Send.ZC_SYNC_END(caster, skillHandle, 0);
			Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle);
			Send.ZC_SKILL_MELEE_TARGET(caster, skill, caster);

			skillHandle = ZoneServer.Instance.World.CreateSkillHandle();
			Send.ZC_SYNC_START(caster, skillHandle, 1);
			var buff = new Buff(BuffId.Warcry_Buff, 0, 0, TimeSpan.FromSeconds(12), caster, caster);
			caster.Components.Get<BuffComponent>()?.AddOrUpdate(buff);
			Send.ZC_SYNC_END(caster, skillHandle, 0);
			Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, TimeSpan.FromMilliseconds(200));
			//Send.ZC_SKILL_HIT_INFO(caster, skill, hits);
			Send.ZC_NORMAL.Skill_45(caster);
		}
	}
}
