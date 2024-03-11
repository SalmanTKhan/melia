using System;
using System.Collections.Generic;
using Melia.Shared.L10N;
using Melia.Shared.Game.Const;
using Melia.Shared.World;
using Melia.Zone.Buffs;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Yggdrasil.Logging;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Skills.Handlers.Hwarang
{
	/// <summary>
	/// Handler for the Hwarang skill Pyeon Jeon.
	/// </summary>
	[SkillHandler(SkillId.Hwarang_PyeonJeon)]
	public class PyeonJeon : IDynamicGroundSkillHandler
	{
		public void EndDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (caster is Character character)
			{
				Send.ZC_NORMAL.CancelDynamicCast(character);
				Send.ZC_ENABLE_CONTROL(character.Connection, "", true);
				Send.ZC_LOCK_KEY(character, "", false);
				caster.Properties.SetFloat(PropertyName.FIXMSPD_BM, 0);
				caster.Properties.SetFloat(PropertyName.MSPD, 33);
				caster.Properties.SetFloat(PropertyName.Jumpable, 1);
				Send.ZC_OBJECT_PROPERTY(character, PropertyName.FIXMSPD_BM, PropertyName.MSPD, PropertyName.Jumpable);
				Send.ZC_MOVE_SPEED(character, 0.8f);
				caster.Components.Get<BuffComponent>()?.Remove(BuffId.PyeonJeon_Buff);
				Send.ZC_STOP_SOUND(character, "skl_eff_pyeonjeon_cast");
				switch (character.Gender)
				{
					case Gender.Female:
						Send.ZC_STOP_SOUND(character, "voice_archer_f_pyeonjeon_cast");
						break;
					case Gender.Male:
						Send.ZC_STOP_SOUND(character, "voice_archer_m_pyeonjeon_cast");
						break;
				}
			}
		}

		/// <summary>
		/// Handles skill behavior
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		/// <param name="originPos"></param>
		/// <param name="farPos"></param>
		/// <param name="designatedTarget"></param>
		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, ICombatEntity target)
		{
			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			skill.IncreaseOverheat();
			caster.SetAttackState(true);

			var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();
			Send.ZC_SKILL_READY(caster, skill, skillHandle, originPos, farPos);
			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos);

			var radius = (int)skill.Data.SplashRange * 2;
			var targets = caster.Map.GetAttackableEntitiesInRange(caster, farPos, radius);
			var damageDelay = TimeSpan.FromMilliseconds(200);

			var hits = new List<SkillHitInfo>();

			foreach (var currentTarget in targets.LimitBySDR(caster, skill))
			{
				var skillHitResult = SCR_SkillHit(caster, currentTarget, skill);
				if (currentTarget.TakeDamage(skillHitResult.Damage, caster))
					Send.ZC_SKILL_CAST_CANCEL(caster);

				var skillHit = new SkillHitInfo(caster, currentTarget, skill, skillHitResult, damageDelay, TimeSpan.Zero);
				hits.Add(skillHit);
			}
			Send.ZC_SKILL_HIT_INFO(caster, hits);
		}

		public void StartDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			// Method intentionally left empty.
		}
	}
}
