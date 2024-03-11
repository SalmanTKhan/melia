using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
using Melia.Zone.World.Actors.Monsters;
using Yggdrasil.Logging;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Skills.Handlers.Cryomancer
{
	/// <summary>
	/// Handler for the Cryomancer skill Ice Wall.
	/// </summary>
	[SkillHandler(SkillId.Cryomancer_IceWall)]
	public class IceWall : IDynamicGroundSkillHandler
	{
		public void StartDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (caster is Character character)
			{
				Send.ZC_PLAY_SOUND(character, character.Gender == Gender.Male ? "voice_wiz_m_icewall_cast" : "voice_wiz_icewall_cast");
				Send.ZC_NORMAL.Skill_DynamicCastStart(character, skill.Id);
			}
		}

		public void EndDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (caster is Character character)
			{
				Send.ZC_STOP_SOUND(character, character.Gender == Gender.Male ? "voice_wiz_m_icewall_cast" : "voice_wiz_icewall_cast");
				Send.ZC_NORMAL.Skill_DynamicCastEnd(character, skill.Id, maxCastTime);
			}
		}

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
			Send.ZC_NORMAL.UpdateSkillEffect(caster, caster.Handle, caster.Position, caster.Direction, caster.Position);

			var targets = caster.Map.GetAttackableEntitiesInRange(caster, farPos, (int)skill.Data.SplashRange * 2);
			var damageDelay = TimeSpan.FromMilliseconds(200);

			var hits = new List<SkillHitInfo>();

			foreach (var currentTarget in targets.LimitBySDR(caster, skill))
			{
				var skillHitResult = SCR_SkillHit(caster, currentTarget, skill);
				currentTarget.TakeDamage(skillHitResult.Damage, caster);

				var skillHit = new SkillHitInfo(caster, currentTarget, skill, skillHitResult, damageDelay, TimeSpan.Zero);
				hits.Add(skillHit);
			}

			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos, hits);
			Send.ZC_NORMAL.SkillPad(caster, skill, "Cryomancer_IceWall", farPos, caster.Direction, 0, 18.5f, skillHandle, 12);

			// TODO: Figure out if this possible without variables
			if (caster is Character character)
			{
				if (!character.Variables.Temp.TryGet<Position>("SkillCellCastPosition", out var cellPosition))
				{
					Log.Warning("No cell position found for skill {0}.", skill.Id);
					return;
				}
				if (!character.Variables.Temp.TryGet<Direction>("SkillCellCastDirection", out var cellDirection))
				{
					Log.Warning("No cell direction found for skill {0}.", skill.Id);
					return;
				}
				if (!character.Variables.Temp.TryGetInt("SkillCellCount", out var cellCount))
				{
					Log.Warning("No cell count found for skill {0}.", skill.Id);
					return;
				}

				if (!character.Variables.Temp.TryGet<List<SkillCellPosition>>("SkillCellList", out var cells))
				{
					Log.Warning("No cells found for skill {0}", skill.Id);
					return;
				}
				for (var i = 0; i < cellCount; i++)
				{
					var cell = cells[i];
					{
						var iceWall = new Mob(47452, MonsterType.Mob);
						iceWall.Faction = FactionType.IceWall;
						iceWall.Position = (cellPosition + new Position(cell.X * 17 + 8, -0.10f, cell.Y * -17)).Floor;
						iceWall.Components.Add(new LifeTimeComponent(iceWall, TimeSpan.FromSeconds(15)));
						iceWall.Died += this.IceWall_Died;
						caster.Map.AddMonster(iceWall);

						targets = caster.Map.GetAttackableEntitiesInRange(caster, iceWall.Position, 17);

						foreach (var currentTarget in targets.LimitBySDR(caster, skill))
						{
							var buff = new Buff(BuffId.Cryomancer_Freeze, 0, 0, TimeSpan.FromSeconds(5), currentTarget, caster);
							//buff.Skill = skill;
							Send.ZC_SYNC_START(caster, skillHandle, 1);
							currentTarget.Components.Get<BuffComponent>().AddOrUpdate(buff);
							Send.ZC_SYNC_END(caster, skillHandle, 0);
							Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, TimeSpan.FromMilliseconds(400));
						}
					}
				}
				Task.Delay(TimeSpan.FromSeconds(15)).ContinueWith(_ => Send.ZC_NORMAL.SkillPad(caster, skill, "Cryomancer_IceWall", farPos, caster.Direction, 0, 18.5f, skillHandle, 12, false));
			}
		}

		private void IceWall_Died(ICombatEntity killed, ICombatEntity killer)
		{
			Send.ZC_LEAVE(killed, LeaveType.Item);
		}
	}
}
