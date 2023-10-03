using System;
using System.Threading.Tasks;
using Melia.Shared.L10N;
using Melia.Shared.Tos.Const;
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

namespace Melia.Zone.Skills.Handlers.Cryomancer
{
	/// <summary>
	/// Handler for the Cryomancer skill Frost Pillar.
	/// </summary>
	[SkillHandler(SkillId.Cryomancer_FrostPillar)]
	public class FrostPillar : IDynamicGroundSkillHandler
	{
		public void StartDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (caster is Character character)
			{
				Send.ZC_PLAY_SOUND(caster, character.Gender == Gender.Male ? "voice_wiz_m_frostpillar_cast" : "voice_wiz_frostpillar_cast");
				Send.ZC_NORMAL.Skill_DynamicCastStart(character, skill.Id);
			}
		}

		public void EndDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (caster is Character character)
			{
				Send.ZC_STOP_SOUND(character, character.Gender == Gender.Male ? "voice_wiz_m_frostpillar_cast" : "voice_wiz_frostpillar_cast");
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
			Send.ZC_NORMAL.SkillPad(caster, skill, "Cryomancer_FrostPillar", farPos, caster.Direction, 0.06292176f, 85.76556f, skillHandle, 60);

			var tree = new Mob(41400, MonsterType.Friendly);
			tree.Faction = FactionType.Law;
			tree.Position = (farPos + new Position(0, -0.10f, 0)).Floor;
			tree.Components.Add(new LifeTimeComponent(tree, TimeSpan.FromSeconds(10)));
			tree.OwnerHandle = caster.Handle;
			tree.AssociatedHandle = caster.Handle;
			tree.Died += (killer, killed) =>
			{
				killed.Components.Get<BuffComponent>().RemoveAll();
				Send.ZC_NORMAL.ClearEffects(killed);
				// Compensate for Disappearance Time (Additional 2 seconds)
				Task.Delay(2000).ContinueWith(_ =>
				{
					Send.ZC_NORMAL.SkillPad(caster, skill, "Cryomancer_FrostPillar", farPos, caster.Direction, 0.06292176f, 85.76556f, skillHandle, 60, false);
				});
			};
			caster.Map.AddMonster(tree);

			var buff = new Buff(BuffId.Cryomancer_Object_Buff, 0, 0, TimeSpan.FromSeconds(0), tree, caster);
			Send.ZC_SYNC_START(caster, skillHandle, 1);
			caster.Components.Get<BuffComponent>()?.AddOrUpdate(buff);
			Send.ZC_SYNC_END(caster, skillHandle, 0);
			Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, TimeSpan.FromMilliseconds(300));

			var targets = caster.Map.GetAttackableEntitiesInRange(caster, farPos, (int)skill.Data.SplashRange * 4);

			Send.ZC_SKILL_RANGE_CIRCLE(caster, originPos, 50);
			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos);

			foreach (var currentTarget in targets.LimitBySDR(caster, skill))
			{
				Send.ZC_NORMAL.PlayTextEffect(currentTarget, caster, AnimationName.ShowBuffText, 301);
				var frostPillar = new Buff(BuffId.Cryomancer_FrostPillar, 0, 0, TimeSpan.FromSeconds(3), currentTarget, caster);
				//frostPillar.Skill = skill;
				var gustDebuff = new Buff(BuffId.Gust_Debuff, 0, 0, TimeSpan.FromSeconds(0), currentTarget, caster);
				//gustDebuff.Skill = skill;
				var frostPillarDebuff = new Buff(BuffId.FrostPillar_Debuff, 0, 0, TimeSpan.FromMilliseconds(1), currentTarget, caster);
				//frostPillarDebuff.Skill = skill;
				currentTarget.Components.Get<BuffComponent>()?.AddOrUpdate(frostPillar, gustDebuff, frostPillarDebuff);
				Send.ZC_SYNC_END(caster, skillHandle, 0);
				Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, TimeSpan.FromMilliseconds(100));
			}
		}
	}
}
