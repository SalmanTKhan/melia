using System;
using Melia.Shared.L10N;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Buffs;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.CombatEntities.Components;

namespace Melia.Zone.Skills.Handlers.Kriwi
{
	/// <summary>
	/// Handler for the Kriwi skill Zaibas.
	/// </summary>
	[SkillHandler(SkillId.Kriwi_Zaibas)]
	public class Zaibas : IGroundSkillHandler
	{
		/// <summary>
		/// Handles skill behavior
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		/// <param name="originPos"></param>
		/// <param name="farPos"></param>
		/// <param name="target"></param>
		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, ICombatEntity target)
		{
			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			skill.IncreaseOverheat();
			caster.SetAttackState(true);

			var radius = (int)skill.Data.SplashRange * 2;
			var targets = caster.Map.GetAttackableEntitiesInRange(caster, farPos, radius);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, 0, caster.Position, caster.Direction, Position.Zero);
			var zaibasSpeedBuff = new Buff(BuffId.ZaibasSPD_Buff, 0, 0, TimeSpan.FromSeconds(3), caster, caster);
			//zaibasSpeedBuff.Skill = skill;
			var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();
			Send.ZC_SYNC_START(caster, skillHandle, 1);
			caster.Components.Get<BuffComponent>()?.AddOrUpdate(zaibasSpeedBuff);
			Send.ZC_SYNC_END(caster, skillHandle, 0);
			Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, TimeSpan.FromMilliseconds(200));
			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos);


			foreach (var currentTarget in targets.LimitBySDR(caster, skill))
			{
				var zaibasStunDebuff = new Buff(BuffId.ZaibasStun_Debuff, 0, 0, TimeSpan.FromMilliseconds(200), currentTarget, caster);
				//zaibasStunDebuff.Skill = skill;
				var brillianceDebuff = new Buff(BuffId.Luminosity_Debuff, 0, 0, TimeSpan.FromSeconds(10), currentTarget, caster);
				//brillianceDebuff.Skill = skill;
				skillHandle = ZoneServer.Instance.World.CreateSkillHandle();
				Send.ZC_SYNC_START(caster, skillHandle, 1);
				currentTarget.Components.Get<BuffComponent>()?.AddOrUpdate(zaibasStunDebuff, brillianceDebuff);
				Send.ZC_SYNC_END(caster, skillHandle, 0);
				Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, TimeSpan.FromMilliseconds(200));
			}
		}
	}
}
