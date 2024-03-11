//--- Melia Script -----------------------------------------------------------
// Alembique Tales(6)
//--- Description -----------------------------------------------------------
// Quest to Talk to Commanding Officer Gigho.
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

[QuestScript(60215)]
public class Quest60215Script : QuestScript
{
	protected override void Load()
	{
		SetId(60215);
		SetName("Alembique Tales(6)");
		SetDescription("Talk to Commanding Officer Gigho");

		AddPrerequisite(new LevelPrerequisite(320));
		AddPrerequisite(new CompletedPrerequisite("LSCAVE551_SQ_6"));

		AddObjective("collect0", "Collect 8 Mecenary Company Antidote(s)", new CollectItemObjective("LSCAVE551_SQ_6_ITEM", 8));
		AddDrop("LSCAVE551_SQ_6_ITEM", 5f, 58477, 58478, 58479, 58570);

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15040));

		AddDialogHook("LSCAVE551_GIGO_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("LSCAVE551_SQ_6_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LSCAVE551_SQ_7_1", "LSCAVE551_SQ_7", "I will find it. Just hold on.", "There must be some other way."))
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

		if (character.Inventory.HasItem("LSCAVE551_SQ_6_ITEM", 8))
		{
			character.Inventory.RemoveItem("LSCAVE551_SQ_6_ITEM", 8);
			character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Commanding Officer Gigho has disappeared.{nl}Report to Priest Celvica.");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

