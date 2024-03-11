using Melia.Shared.Game.Const;
using Melia.Zone.Buffs.Base;
using Melia.Zone.Network;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Monsters;

namespace Melia.Zone.Buffs.Handlers
{
	/// <summary>
	/// Handle for the Gather Corpse, 
	/// Collects fragments of defeated enemies affected by the debuff..
	/// </summary>
	[BuffHandler(BuffId.GatherCorpse_Debuff)]
	public class GatherCorpse_Debuff : BuffHandler
	{
		public override void OnEnd(Buff buff)
		{
			var target = buff.Target;

			if (target.IsDead && target is Mob mob && buff.Caster is Character character)
			{
				// TODO: Figure out which ability changes this to 1000 max parts.
				var maxParts = 300;

				for (var i = 1; i < maxParts; i++)
					if (character.EtcProperties.Has("NecroDParts_" + i))
						character.EtcProperties.SetFloat("NecroDParts_" + i, mob.Id);

				var currentParts = character.EtcProperties.GetFloat(PropertyName.Necro_DeadPartsCnt);

				if (currentParts < maxParts)
				{
					character.ModifyEtcProperty(PropertyName.Necro_DeadPartsCnt, 1);
					character.AddonMessage(AddonMessage.UPDATE_NECRONOMICON_UI);
				}

				Send.ZC_NORMAL.PlayGatherCorpseParts(character, buff.Target);
				Send.ZC_PLAY_SOUND(character, "skl_eff_gathercorpse_whoosh");
				Send.ZC_PLAY_SOUND(character, "skl_eff_partscapture_finish");
			}
		}
	}
}
