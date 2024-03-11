//--- Melia Script -----------------------------------------------------------
// Eliminate the competitor
//--- Description -----------------------------------------------------------
// Quest to Talk to Indraja.
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

[QuestScript(70844)]
public class Quest70844Script : QuestScript
{
	protected override void Load()
	{
		SetId(70844);
		SetName("Eliminate the competitor");
		SetDescription("Talk to Indraja");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "WHITETREES23_3_SQ05_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(323));
		AddPrerequisite(new CompletedPrerequisite("WHITETREES23_3_SQ02"), new CompletedPrerequisite("WHITETREES23_3_SQ04"));

		AddObjective("collect0", "Collect 1 Royal Family Chest", new CollectItemObjective("WHITETREES23_3_SQ05_ITEM", 1));
		AddDrop("WHITETREES23_3_SQ05_ITEM", 10f, "boss_Frogola_Q1");

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15181));

		AddDialogHook("WHITETREES233_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("WHITETREES233_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WHITETREES233_SQ_05_start", "WHITETREES23_3_SQ05", "I will try", "Say that you are not able to face the demons"))
		{
			case 1:
				await dialog.Msg("WHITETREES233_SQ_05_agree");
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

		if (character.Inventory.HasItem("WHITETREES23_3_SQ05_ITEM", 1))
		{
			character.Inventory.RemoveItem("WHITETREES23_3_SQ05_ITEM", 1);
			await dialog.Msg("WHITETREES233_SQ_05_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

