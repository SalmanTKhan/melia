using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Melia.Shared.Game.Const;
using Melia.Shared.World;
using Melia.Zone.Buffs.Base;
using Melia.Zone.Network;

namespace Melia.Zone.Buffs.Handlers
{
	/// <summary>
	/// Handler for Coursing Debuff.
	/// </summary>
	[BuffHandler(BuffId.Coursing_Debuff)]
	public class Coursing_Debuff : BuffHandler
	{
		public override void OnStart(Buff buff)
		{
			Send.ZC_NORMAL.Skill_127(buff.Caster, buff.Target.Handle, 370256, buff.Target.Position);
		}

		public override void OnEnd(Buff buff)
		{
			Send.ZC_NORMAL.Skill_127(buff.Caster, 0, 0, Position.Zero);
		}
	}
}
