//--- Melia Script -----------------------------------------------------------
// Where is the Recruit? (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Abraomas.
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

[QuestScript(72113)]
public class Quest72113Script : QuestScript
{
	protected override void Load()
	{
		SetId(72113);
		SetName("Where is the Recruit? (2)");
		SetDescription("Talk to Abraomas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_3CMLAKE261_SQ14_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(333));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE261_SQ13"));

		AddObjective("collect0", "Collect 1 Dirk Inside Tutu's Body", new CollectItemObjective("3CMLAKE261_SQ14_ITEM", 1));
		AddDrop("3CMLAKE261_SQ14_ITEM", 10f, "boss_tutu_Q3");

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));
		AddReward(new ItemReward("Vis", 15651));

		AddDialogHook("3CMLAKE_ABRAOMAS", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_ABRAOMAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("3CMLAKE261_SQ14_DLG01", "F_3CMLAKE261_SQ14", "I'll look into this.", "This will be too difficult to investigate."))
		{
			case 1:
				await dialog.Msg("3CMLAKE261_SQ14_DLG02");
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

		if (character.Inventory.HasItem("3CMLAKE261_SQ14_ITEM", 1))
		{
			character.Inventory.RemoveItem("3CMLAKE261_SQ14_ITEM", 1);
			await dialog.Msg("3CMLAKE261_SQ14_DLG04");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

