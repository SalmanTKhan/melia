//--- Melia Script -----------------------------------------------------------
// A Request from Goddess Saule (2)
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

[QuestScript(50039)]
public class Quest50039Script : QuestScript
{
	protected override void Load()
	{
		SetId(50039);
		SetName("A Request from Goddess Saule (2)");
		SetDescription("Talk to Goddess Saule");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PARTY_Q_061_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(100));
		AddPrerequisite(new CompletedPrerequisite("PARTY_Q_060"));

		AddDialogHook("HUEVILLAGE_58_4_SAULE_AFTER", "BeforeStart", BeforeStart);
		AddDialogHook("HUEVILLAGE_58_4_SAULE_AFTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PARTY_Q_061_startnpc01", "PARTY_Q_061", "I'll go there", "Tell him that it's hard to accept"))
		{
			case 1:
				dialog.UnHideNPC("SAULE_PURIFICATION");
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

		await dialog.Msg("PARTY_Q_061_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

