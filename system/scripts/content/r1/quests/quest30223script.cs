//--- Melia Script -----------------------------------------------------------
// Investigate Inner Wall District 8 (4)
//--- Description -----------------------------------------------------------
// Quest to Chest the material storage chest.
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

[QuestScript(30223)]
public class Quest30223Script : QuestScript
{
	protected override void Load()
	{
		SetId(30223);
		SetName("Investigate Inner Wall District 8 (4)");
		SetDescription("Chest the material storage chest");

		AddPrerequisite(new LevelPrerequisite(279));
		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_3_SQ_4"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("CASTLE_20_3_SQ_6_ITEM", 1));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11439));

		AddDialogHook("CASTLE_20_3_OBJ_8", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE_20_3_OBJ_8", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("CASTLE_20_3_SQ_5_ITEM_3", 1))
		{
			character.Inventory.RemoveItem("CASTLE_20_3_SQ_5_ITEM_3", 1);
			ZoneServer.Instance.World.FindNPC("CASTLE_20_3_OBJ_8")?.PlayEffectLocal(character.Connection, "F_burstup007_smoke1", 0.6f, "BOT");
			dialog.HideNPC("CASTLE_20_3_OBJ_8");
			dialog.UnHideNPC("CASTLE_20_3_OBJ_8_AFTER");
			character.AddonMessage(AddonMessage.NOTICE_Dm_Scroll, "There is Magic Circle Maintenance Department near the magical eye.{nl}Check the content.");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

