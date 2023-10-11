//--- Melia Script -----------------------------------------------------------
// Trace Race (5)
//--- Description -----------------------------------------------------------
// Quest to Talk with Kupole Leda.
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

[QuestScript(90152)]
public class Quest90152Script : QuestScript
{
	protected override void Load()
	{
		SetId(90152);
		SetName("Trace Race (5)");
		SetDescription("Talk with Kupole Leda");

		AddPrerequisite(new LevelPrerequisite(295));
		AddPrerequisite(new CompletedPrerequisite("F_DCAPITAL_20_6_SQ_50"));

		AddObjective("collect0", "Collect 8 Demon Magic Stone Fragment(s)", new CollectItemObjective("F_DCAPITAL_20_6_SQ_55_ITEM1", 8));
		AddDrop("F_DCAPITAL_20_6_SQ_55_ITEM1", 10f, 58558, 58559);

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 12390));

		AddDialogHook("DCAPITAL_20_6_REDA", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL_20_6_REDA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_DCAPITAL_20_6_SQ_55_ST", "F_DCAPITAL_20_6_SQ_55", "What needs to be prepared?", "I will wait for the preparation to be completed."))
		{
			case 1:
				await dialog.Msg("F_DCAPITAL_20_6_SQ_55_AG");
				dialog.UnHideNPC("DCAPITAL_20_6_SQ_55");
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

		if (character.Inventory.HasItem("F_DCAPITAL_20_6_SQ_55_ITEM1", 8) && character.Inventory.HasItem("F_DCAPITAL_20_6_SQ_55_ITEM2", 4))
		{
			character.Inventory.RemoveItem("F_DCAPITAL_20_6_SQ_55_ITEM1", 8);
			character.Inventory.RemoveItem("F_DCAPITAL_20_6_SQ_55_ITEM2", 4);
			await dialog.Msg("F_DCAPITAL_20_6_SQ_55_SU");
			dialog.HideNPC("DCAPITAL_20_6_SQ_55");
			await dialog.Msg("NPCAin/DCAPITAL_20_6_REDA/atk/0");
			ZoneServer.Instance.World.FindNPC("DCAPITAL_20_6_REDA")?.PlayEffectLocal(character.Connection, "I_light013_spark_yellow", 2f, "BOT");
			character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Kupole Leda has granted enhanced the divine energy detector orb.");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

