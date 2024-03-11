//--- Melia Script -----------------------------------------------------------
// Methods to Reducing Fever
//--- Description -----------------------------------------------------------
// Quest to Talk with Ades.
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

[QuestScript(70224)]
public class Quest70224Script : QuestScript
{
	protected override void Load()
	{
		SetId(70224);
		SetName("Methods to Reducing Fever");
		SetDescription("Talk with Ades");

		AddPrerequisite(new LevelPrerequisite(215));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND28_2_SQ01"));

		AddReward(new ExpReward(1082046, 1082046));
		AddReward(new ItemReward("expCard11", 4));
		AddReward(new ItemReward("Vis", 7525));

		AddDialogHook("TABLELAND282_SQ_05", "BeforeStart", BeforeStart);
		AddDialogHook("TABLELAND282_SQ_05", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND28_2_SQ_05_1", "TABLELAND28_2_SQ05", "How can I help you?", "The duty at Stogas", "I don't have time to help you"))
		{
			case 1:
				await dialog.Msg("TABLELAND28_2_SQ_05_2");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("TABLELAND28_2_SQ_05_1_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("TABLELAND28_2_SQ05_ITEM", 5))
		{
			character.Inventory.RemoveItem("TABLELAND28_2_SQ05_ITEM", 5);
			await dialog.Msg("TABLELAND28_2_SQ_05_4");
			await dialog.Msg("FadeOutIN/1000");
			dialog.UnHideNPC("TABLELAND282_SQ_06");
			dialog.HideNPC("TABLELAND282_SQ_05_P");
			await dialog.Msg("NPCAin/TABLELAND282_SQ_06_F/ON/1");
			dialog.HideNPC("TABLELAND282_SQ_01");
			dialog.UnHideNPC("TABLELAND282_SQ_01_R");
			await dialog.Msg("TABLELAND28_2_SQ_05_5");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

