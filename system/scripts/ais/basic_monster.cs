using System.Collections;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.AI;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Monsters;

[Ai("BasicMonster")]
public class BasicMonsterAiScript : AiScript
{
	private const int MaxChaseDistance = 300;
	private const int MaxMasterDistance = 200;
	private const int MaxRoamDistance = 300;

	private ICombatEntity _target;

	protected override void Setup()
	{
		During("Idle", CheckEnemies);
		During("Attack", CheckTarget);
		During("Attack", CheckMaster);
	}

	protected override void Root()
	{
		StartRoutine("ReturnHome", ReturnHome());
	}

	protected IEnumerable Idle()
	{
		ResetMoveSpeed();

		var master = GetMaster();
		if (master != null)
		{
			yield return Animation("IDLE");
			yield return Follow(master);
			yield break;
		}

		yield return Wait(4000, 8000);

		SwitchRandom();
		if (Case(80))
		{
			yield return MoveRandom();
		}
		else
		{
			yield return Animation("IDLE");
		}
	}

	protected IEnumerable Attack()
	{
		SetRunning(true);

		while (!_target.IsDead)
		{
			if (!TryGetRandomSkill(out var skill))
			{
				yield return Wait(2000);
				continue;
			}

			while (!InRangeOf(_target, skill.GetAttackRange()))
				yield return MoveTo(_target.Position, wait: false);

			yield return StopMove();

			yield return UseSkill(skill, _target);
			yield return Wait(skill.Properties.Delay);
		}

		yield break;
	}

	protected IEnumerable StopAndIdle()
	{
		yield return StopMove();
		StartRoutine("Idle", Idle());
	}

	protected IEnumerable StopAndAttack()
	{
		ExecuteOnce(Emoticon("I_emo_exclamation"));
		ExecuteOnce(TurnTowards(_target));

		yield return StopMove();
		StartRoutine("Attack", Attack());
	}

	private void CheckEnemies()
	{
		var mostHated = GetMostHated();
		if (mostHated != null)
		{
			_target = mostHated;
			StartRoutine("StopAndAttack", StopAndAttack());
		}
	}

	private void CheckTarget()
	{
		// Transition to idle if the target has vanished or is out of range
		if (EntityGone(_target) || !InRangeOf(_target, MaxChaseDistance) || !IsHating(_target))
		{
			_target = null;
			StartRoutine("StopAndIdle", StopAndIdle());
		}
	}

	private void CheckMaster()
	{
		if (_target == null)
			return;

		if (!TryGetMaster(out var master))
			return;

		// Reset aggro if the master left
		if (EntityGone(master) || !InRangeOf(master, MaxMasterDistance))
		{
			_target = null;
			RemoveAllHate();
			StartRoutine("StopAndIdle", StopAndIdle());
		}
	}

	protected IEnumerable ReturnHome()
	{
		if (this.Entity is IMonster monster && monster.SpawnLocation != null
			&& monster.SpawnLocation.Position.Get2DDistance(monster.Position) > MaxRoamDistance)
		{
			SetRunning(true);
			yield return MoveTo(monster.SpawnLocation.Position.GetRandomInRange2D(15, 30));
		}
		StartRoutine("Idle", Idle());
	}
}
