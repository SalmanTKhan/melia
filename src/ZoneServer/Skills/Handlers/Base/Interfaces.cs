using System.Collections.Generic;
using Melia.Shared.World;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.CombatEntities.Components;

namespace Melia.Zone.Skills.Handlers.Base
{
	public interface ISkillHandler
	{
	}

	public interface ITargetSkillHandler : ISkillHandler
	{
		void Handle(Skill skill, ICombatEntity caster, ICombatEntity target);
	}

	public interface ITargetAniSkillHandler : ISkillHandler
	{
		void Handle(Skill skill, ICombatEntity caster, Direction dir);
	}

	public interface IGroundSkillHandler : ISkillHandler
	{
		void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, ICombatEntity designatedTarget);
	}

	public interface IMeleeGroundSkillHandler : ISkillHandler
	{
		void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, IList<ICombatEntity> targets);
	}

	public interface IForceSkillHandler : ISkillHandler
	{
		void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, IList<ICombatEntity> targets);
	}

	public interface ISelfSkillHandler : ISkillHandler
	{
		void Handle(Skill skill, ICombatEntity caster, Position originPos, Direction dir);
	}

	public interface IPassiveSkillHandler : ISkillHandler
	{
		void Handle(Skill skill, ICombatEntity caster);
	}

	/// <summary>
	/// A skill handler interface when the client provides a target
	/// </summary>
	public interface IDynamicCasted : ISkillHandler
	{
		void StartDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime);
		void EndDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime);
	}

	public interface IDynamicGroundSkillHandler : IGroundSkillHandler, IDynamicCasted { }
	public interface IDynamicForceSkillHandler : IForceSkillHandler, IDynamicCasted { }
	public interface IDynamicTargetSkillHandler : ITargetSkillHandler, IDynamicCasted { }
}
