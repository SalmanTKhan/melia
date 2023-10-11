//--- Melia Script -----------------------------------------------------------
// A Request from Goddess Saule (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Saule.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Zone;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;

[QuestScript(50038)]
public class Quest50038Script : QuestScript
{
	protected override void Load()
	{
		SetId(50038);
		SetName("A Request from Goddess Saule (1)");
		SetDescription("Talk to Goddess Saule");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PARTY_Q_060_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(100));

		AddObjective("kill0", "Kill 6 Bramble's Root(s) or Bramble's Root(s) or Bramble's Root(s)", new KillObjective(6, 153011, 153039, 153058));

		AddDialogHook("HUEVILLAGE_58_4_SAULE_AFTER", "BeforeStart", BeforeStart);
		AddDialogHook("HUEVILLAGE_58_4_SAULE_AFTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PARTY_Q_060_startnpc01", "PARTY_Q_060", "Ask him how you can help", "I need some time to prepare"))
		{
			case 1:
				await dialog.Msg("PARTY_Q_060_startnpc02");
				dialog.UnHideNPC("PARTY_Q06_THORN");
				dialog.UnHideNPC("PARTY_Q06_THORN02");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("PARTY_Q_060_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

