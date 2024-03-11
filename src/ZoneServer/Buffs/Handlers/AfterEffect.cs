using Melia.Shared.Game.Const;
using Melia.Zone.Buffs.Base;
using Melia.Zone.Network;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Characters.Components;
using static Melia.Shared.Network.NormalOp;

namespace Melia.Zone.Buffs.Handlers
{
	/// <summary>
	/// Handle for the Resurrection After Effects, 
	/// The after effect of being revived. Decreased most of your combat skills..
	/// </summary>
	[BuffHandler(BuffId.AfterEffect)]
	public class AfterEffect : BuffHandler
	{
		private const float AttackBonus = -0.5f;
		private const float DefenseBonus = -0.5f;
		private const float MagicAttackBonus = -0.5f;

		public override void OnStart(Buff buff)
		{
			var target = buff.Target;

			target.Properties.Modify(PropertyName.ATK_BM, AttackBonus);
			target.Properties.Modify(PropertyName.DEF_RATE_BM, DefenseBonus);
			target.Properties.Modify(PropertyName.MATK_RATE_BM, MagicAttackBonus);

			if (target is Character character)
				Send.ZC_OBJECT_PROPERTY(character, PropertyName.ATK_BM, PropertyName.DEF_RATE_BM, PropertyName.MATK_RATE_BM);
		}

		public override void OnEnd(Buff buff)
		{
			var target = buff.Target;

			target.Properties.Modify(PropertyName.ATK_BM, -AttackBonus);
			target.Properties.Modify(PropertyName.DEF_RATE_BM, -DefenseBonus);
			target.Properties.Modify(PropertyName.MATK_RATE_BM, -MagicAttackBonus);

			if (target is Character character)
				Send.ZC_OBJECT_PROPERTY(character, PropertyName.ATK_BM, PropertyName.DEF_RATE_BM, PropertyName.MATK_RATE_BM);
		}
	}
}
