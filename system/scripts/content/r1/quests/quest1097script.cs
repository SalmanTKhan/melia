//--- Melia Script -----------------------------------------------------------
// Dream Book of the Bow 4 [Ranger Advancement] (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Ranger Master.
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

[QuestScript(1097)]
public class Quest1097Script : QuestScript
{
	protected override void Load()
	{
		SetId(1097);
		SetName("Dream Book of the Bow 4 [Ranger Advancement] (3)");
		SetDescription("Talk to the Ranger Master");

		AddPrerequisite(new LevelPrerequisite(45));
		AddPrerequisite(new CompletedPrerequisite("JOB_RANGER2_2"));

		AddObjective("collect0", "Collect 2 Tough Glizardon Leather(s)", new CollectItemObjective("JOB_HUNTER2_2_ITEM1", 2));
		AddDrop("JOB_HUNTER2_2_ITEM1", 10f, "Glizardon");

		AddReward(new ItemReward("Book4", 1));

		AddDialogHook("MASTER_RANGER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_QU", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_RANGER2_3_select1", "JOB_RANGER2_3", "I will get the leather and bring the book", "I'll quit here"))
		{
			case 1:
				await dialog.Msg("JOB_RANGER2_3_agree1");
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

		if (character.Inventory.HasItem("JOB_HUNTER2_2_ITEM1", 2))
		{
			character.Inventory.RemoveItem("JOB_HUNTER2_2_ITEM1", 2);
			ZoneServer.Instance.World.FindNPC("MASTER_QU")?.PlayEffectLocal(character.Connection, "archer_buff_skl_Recuperate_circle", 1.5f, "BOT");
			await dialog.Msg("JOB_RANGER2_3_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}
