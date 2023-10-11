//--- Melia Script -----------------------------------------------------------
// Different Circumstances (8)
//--- Description -----------------------------------------------------------
// Quest to Defeat Monsters to Collect Cornerstone Pieces.
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

[QuestScript(60418)]
public class Quest60418Script : QuestScript
{
	protected override void Load()
	{
		SetId(60418);
		SetName("Different Circumstances (8)");
		SetDescription("Defeat Monsters to Collect Cornerstone Pieces");

		AddPrerequisite(new LevelPrerequisite(401));
		AddPrerequisite(new CompletedPrerequisite("CASTLE96_MQ_7"));

		AddObjective("collect0", "Collect 15 Cornerstone Piece(s)", new CollectItemObjective("CASTLE96_MQ_7_ITEM", 15));
		AddDrop("CASTLE96_MQ_7_ITEM", 10f, 59236, 59244, 59248);

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 22857));

		AddDialogHook("CASTLE96_MQ_TADAS_NPC_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("CASTLE96_MQ_7_ITEM", 15))
		{
			character.Inventory.RemoveItem("CASTLE96_MQ_7_ITEM", 15);
			await dialog.Msg("CASTLE96_MQ_8_3");
			await dialog.Msg("FadeOutIN/3000");
			dialog.UnHideNPC("CASTLE96_MQ_NERGUI_NPC");
			// Func/CASTLE96_FOLLOWNPC_LIB_CANCEL/0;
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnStart(Character character, Quest quest)
	{
		// Func/CASTLE96_FOLLOWNPC_LIB/CASTLE96_MQ_7;
		character.AddonMessage(AddonMessage.NOTICE_Dm_Scroll, "There's no more time to waste.{nl}Defeat the monsters to collect Cornerstone Pieces!");
	}
}

