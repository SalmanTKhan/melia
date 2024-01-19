using System;
using System.Threading.Tasks;
using Melia.Shared.L10N;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Buffs;
using Melia.Zone.Network;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Melia.Zone.World.Actors.Monsters;

namespace Melia.Zone.Skills.Handlers.Archer.Engineer
{
	/// <summary>
	/// Handler for the Engineer skill Flame Turret.
	/// </summary>
	[SkillHandler(SkillId.Engineer_FlameTurret)]
	public class FlameTurret : IGroundSkillHandler
	{
		/// <summary>
		/// Handles skill behavior.
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

			var groundEffectHandle = ZoneServer.Instance.World.CreateEffectHandle();

			Send.ZC_SKILL_READY(caster, skill, 1, caster.Position, originPos);
			Send.ZC_NORMAL.SkillPad(caster, skill, "Engineer_FlameTurret_Default", caster.Position, caster.Direction, 0, 0, groundEffectHandle, 100);

			var turret = new Mob(300041, MonsterType.Friendly);
			turret.Faction = FactionType.Law;
			turret.Position = caster.Position;
			turret.Components.Add(new LifeTimeComponent(turret, TimeSpan.FromSeconds(15)));
			turret.OwnerHandle = caster.Handle;
			turret.AssociatedHandle = caster.Handle;
			turret.Died += (killed, killer) =>
			{
				killed.Components?.Get<BuffComponent>()?.RemoveAll();
				Send.ZC_NORMAL.ClearEffects(killed);
				// Compensate for Disappearance Time (Additional 2 seconds)
				Task.Delay(2000).ContinueWith(_ =>
				{
					Send.ZC_NORMAL.SkillPad(caster, skill, "Engineer_FlameTurret_Default", caster.Position, caster.Direction, 0, 0, groundEffectHandle, 100, false);
				});
			};
			caster.Map.AddMonster(turret);

			var key = ZoneServer.Instance.World.CreateSkillHandle();

			Send.ZC_SYNC_START(caster, key, 1);
			caster.StartBuff(BuffId.Cryomancer_Object_Buff, 0, 0, TimeSpan.FromSeconds(0), turret);
			Send.ZC_SYNC_END(caster, key, 0);
			Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, key, TimeSpan.FromMilliseconds(400));
		}
	}
}
