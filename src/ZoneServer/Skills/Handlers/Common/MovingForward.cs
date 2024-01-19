using System;
using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.World.Actors;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Shared.L10N;
using Melia.Zone.Skills.Combat;

namespace Melia.Zone.Skills.Handlers.Common
{
	/// <summary>
	/// Handler for the Common skill Moving Forward.
	/// </summary>
	[SkillHandler(SkillId.Common_MovingForward)]
	public class MovingForward : IGroundSkillHandler
	{
		/// <summary>
		/// Handles usage of the skill.
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		/// <param name="originPos"></param>
		/// <param name="farPos"></param>
		/// <param name="targets"></param>
		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, ICombatEntity designatedTarget)
		{
			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			skill.IncreaseOverheat();
			caster.SetAttackState(true);

			var jumpDistance = 40;
			caster.Position.GetRelative(caster.Direction, jumpDistance);

			Send.ZC_ON_AFTER_IMAGE(caster, 300f, 500f, 255f, 50f, 50f, 125f);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, 0, caster.Position, caster.Direction, Position.Zero);
			//var key = ZoneServer.Instance.World.CreateSkillHandle();

			//Send.ZC_SYNC_START(caster, key, 1);
			Send.ZC_NORMAL.SetActorColor(caster, 160, 160, 160, 255, 0f, 1);
			caster.StartBuff(BuffId.Skill_NoDamage_Buff, TimeSpan.FromSeconds(1));
			//Send.ZC_SYNC_END(caster, key, 0);
			//Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, key, TimeSpan.Zero);

			var forceId = ForceId.GetNew();
			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos, forceId, null);

			Task.Delay(250).ContinueWith(_ =>
			{
				Send.ZC_OFF_AFTER_IMAGE(caster);
				Send.ZC_NORMAL.SetActorColor(caster, 255, 255, 255, 255, 0f, 1);
			});
		}
	}
}
