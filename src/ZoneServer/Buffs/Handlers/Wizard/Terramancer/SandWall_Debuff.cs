using System;
using Melia.Shared.Tos.Const;
using Melia.Zone.Buffs.Base;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.World.Actors;
using Yggdrasil.Util;

namespace Melia.Zone.Buffs.Handlers
{
	/// <summary>
	/// Handler for the Sand Wall Debuff
	/// Slow's target for 3 seconds
	/// </summary>
	[BuffHandler(BuffId.SandWall_Debuff)]
	public class SandWall_Debuff : BuffHandler
	{
		private const string VarName = "Melia.MSPDPenalty";
		private const float MSPDPenaltyPerLevel = -1;

		public override void OnStart(Buff buff)
		{
			var target = buff.Target;
			var penalty = this.GetMSPDPenalty(buff);
			buff.Vars.SetFloat(VarName, penalty);

			target.Properties.Modify(PropertyName.MSPD_BM, penalty);
			Send.ZC_SHOW_EMOTICON(target, "I_emo_slowdown", buff.Duration);
		}

		public override void OnEnd(Buff buff)
		{
			var target = buff.Target;

			if (buff.Vars.TryGetFloat(VarName, out var penalty))
				target.Properties.Modify(PropertyName.MSPD_BM, -penalty);
			Send.ZC_SHOW_EMOTICON(target, "I_emo_slowdown", TimeSpan.Zero);
		}

		private float GetMSPDPenalty(Buff buff)
		{
			var skillLevel = buff.NumArg1;
			var bonus = -10 + skillLevel * MSPDPenaltyPerLevel;

			return bonus;
		}
	}
}
