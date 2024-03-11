//--- Melia Script -----------------------------------------------------------
// Last Mission (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Officer's Spirit.
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

[QuestScript(8227)]
public class Quest8227Script : QuestScript
{
	protected override void Load()
	{
		SetId(8227);
		SetName("Last Mission (2)");
		SetDescription("Talk to the Officer's Spirit");

		AddPrerequisite(new LevelPrerequisite(107));
		AddPrerequisite(new CompletedPrerequisite("KATYN71_MQ_02"));

		AddObjective("collect0", "Collect 10 Rustling Skin(s)", new CollectItemObjective("KATYN72_DUM_WO_02", 10));
		AddDrop("KATYN72_DUM_WO_02", 6f, "pappus_kepa");

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 2568));

		AddDialogHook("KATYN71_OFFICER", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN71_OFFICER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN71_MQ_03_01", "KATYN71_MQ_03", "I will collect the Old Kepa Skins", "I'm busy so I can only help until here."))
		{
			case 1:
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

		if (character.Inventory.HasItem("KATYN72_DUM_WO_02", 10))
		{
			character.Inventory.RemoveItem("KATYN72_DUM_WO_02", 10);
			await dialog.Msg("KATYN71_MQ_03_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("KATYN71_MQ_04");
	}
}

