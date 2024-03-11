//--- Melia Script -----------------------------------------------------------
// The Final Mission (2)
//--- Description -----------------------------------------------------------
// Quest to Check the Military Backpack.
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

[QuestScript(20238)]
public class Quest20238Script : QuestScript
{
	protected override void Load()
	{
		SetId(20238);
		SetName("The Final Mission (2)");
		SetDescription("Check the Military Backpack");

		AddPrerequisite(new LevelPrerequisite(103));
		AddPrerequisite(new CompletedPrerequisite("REMAIN39_SQ01"));

		AddObjective("collect0", "Collect 9 Zolem Magic Stone(s)", new CollectItemObjective("REMAIN39_SQ02_ITEM", 9));
		AddDrop("REMAIN39_SQ02_ITEM", 10f, "Zolem");

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 2472));

		AddDialogHook("REMAINS39_GHOST_BAG_1", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS39_GHOST_BAG_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAIN39_SQ02_01", "REMAIN39_SQ02", "Carry out the plan for him", "It's all in the past"))
		{
			case 1:
				character.AddonMessage(AddonMessage.NOTICE_Dm_Scroll, "Defeat Zolem and collect Zolem Magic Stones");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

