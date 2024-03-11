//--- Melia Script -----------------------------------------------------------
// Parias Forest Post (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pajauta.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Shared.Game.Const;
using Melia.Zone;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;

[QuestScript(60409)]
public class Quest60409Script : QuestScript
{
	protected override void Load()
	{
		SetId(60409);
		SetName("Parias Forest Post (3)");
		SetDescription("Talk to Pajauta");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PAYAUTA_EP11_10_TRACK", 5000);

		AddPrerequisite(new LevelPrerequisite(380));
		AddPrerequisite(new CompletedPrerequisite("PAYAUTA_EP11_9"));

		AddReward(new ItemReward("expCard16", 1));
		AddReward(new ItemReward("Vis", 20140));

		AddDialogHook("PAYAUTA_EP11_NPC_232_FLLW", "BeforeStart", BeforeStart);
		AddDialogHook("PAYAUTA_EP11_NPC_232_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PAYAUTA_EP11_10_1", "PAYAUTA_EP11_10", "Let's go.", "Please wait"))
		{
			case 1:
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

		await dialog.Msg("PAYAUTA_EP11_10_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

