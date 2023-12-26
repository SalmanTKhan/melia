using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Melia.Shared.Data.Database;
using Melia.Shared.L10N;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Buffs;
using Melia.Zone.Network;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Melia.Zone.World.Actors.Monsters;
using Yggdrasil.Geometry.Shapes;
using Yggdrasil.Logging;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Skills.Handlers.TerraMancer
{
	/// <summary>
	/// Handler for the TerraMancer skill Stone Shower.
	/// </summary>
	[SkillHandler(SkillId.TerraMancer_StoneShower)]
	public class StoneShower : IGroundSkillHandler
	{
		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, ICombatEntity designatedTarget)
		{
			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			skill.IncreaseOverheat();
			caster.SetAttackState(true);

			var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();

			Send.ZC_SKILL_READY(caster, skill, skillHandle, caster.Position, farPos);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, caster.Handle, caster.Position, caster.Direction, caster.Position);

			Send.ZC_GROUND_EFFECT(caster, AnimationName.StoneShower, caster.Position, 0.5f, 0, 0, caster.Direction.DegreeAngle);
			Send.ZC_SYNC_START(caster, skillHandle, 1);
			Send.ZC_SYNC_END(caster, skillHandle, 0);
			Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, TimeSpan.FromMilliseconds(150));

			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos);

			var splashParam = skill.GetSplashParameters(caster, originPos, farPos, length: 130, width: 60, angle: 0);
			var splashArea = skill.GetSplashArea(SplashType.Square, splashParam);
			Debug.ShowShape(caster.Map, splashArea, skill.Data.ShootTime);

			var targets = caster.Map.GetAttackableEntitiesIn(caster, splashArea);

			foreach (var currentTarget in targets.LimitBySDR(caster, skill))
			{
				var forceId = ForceId.GetNew();
				var skillHitResult = SCR_SkillHit(caster, currentTarget, skill);
				currentTarget.TakeDamage(skillHitResult.Damage, caster);

				var hitInfo = new HitInfo(caster, currentTarget, skill, skillHitResult.Damage, skillHitResult.Result);
				hitInfo.ForceId = forceId;

				Send.ZC_HIT_INFO(caster, currentTarget, hitInfo);
			}
		}
	}
}
