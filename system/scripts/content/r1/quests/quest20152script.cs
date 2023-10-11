//--- Melia Script -----------------------------------------------------------
// Gorath's Concern (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Historian Badat.
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

[QuestScript(20152)]
public class Quest20152Script : QuestScript
{
	protected override void Load()
	{
		SetId(20152);
		SetName("Gorath's Concern (2)");
		SetDescription("Talk to Historian Badat");

		AddPrerequisite(new LevelPrerequisite(58));
		AddPrerequisite(new CompletedPrerequisite("ROKAS24_SQ_02"));

		AddObjective("collect0", "Collect 8 Research Material(s)", new CollectItemObjective("ROKAS24_SQ_03_ITEM", 8));
		AddDrop("ROKAS24_SQ_03_ITEM", 10f, "Tontus");

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1044));

		AddDialogHook("ROKAS_24_ARCHAEOLOGIST", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS_24_ARCHAEOLOGIST", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS24_SQ_03_select01", "ROKAS24_SQ_03", "I'll help you find the research data", "About the loss of research data", "Find it and go back quickly"))
		{
			case 1:
				await dialog.Msg("ROKAS24_SQ_03_startnpc01");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("ROKAS24_SQ_03_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("ROKAS24_SQ_03_ITEM", 8))
		{
			character.Inventory.RemoveItem("ROKAS24_SQ_03_ITEM", 8);
			await dialog.Msg("ROKAS24_SQ_03_succ01");
			ZoneServer.Instance.World.FindNPC("ROKAS_24_ARCHAEOLOGIST")?.PlayEffectLocal(character.Connection, "F_ground095_circle", 1f, "BOT");
			await dialog.Msg("FadeOutIN/1000");
			dialog.HideNPC("ROKAS_24_ARCHAEOLOGIST");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

