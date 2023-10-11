//--- Melia Script -----------------------------------------------------------
// Crystal Stone at the Lot
//--- Description -----------------------------------------------------------
// Quest to Talk to the Beholder.
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

[QuestScript(72102)]
public class Quest72102Script : QuestScript
{
	protected override void Load()
	{
		SetId(72102);
		SetName("Crystal Stone at the Lot");
		SetDescription("Talk to the Beholder");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_3CMLAKE261_SQ03_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(333));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE261_SQ02"));

		AddObjective("collect0", "Collect 1 Light Blue Wing", new CollectItemObjective("3CMLAKE261_SQ03_ITEM", 1));
		AddDrop("3CMLAKE261_SQ03_ITEM", 10f, "boss_Carapace_Q2");

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));
		AddReward(new ItemReward("Vis", 15651));

		AddDialogHook("3CMLAKE_BLACKMAN01", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_BLACKMAN01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("3CMLAKE261_SQ03_DLG01", "F_3CMLAKE261_SQ03", "I'll take care of it.", "Ask for more time."))
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

		if (character.Inventory.HasItem("3CMLAKE261_SQ03_ITEM", 1))
		{
			character.Inventory.RemoveItem("3CMLAKE261_SQ03_ITEM", 1);
			await dialog.Msg("3CMLAKE261_SQ03_DLG03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

