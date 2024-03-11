//--- Melia Script -----------------------------------------------------------
// A Legend's Reality
//--- Description -----------------------------------------------------------
// Quest to Talk to Kedora Alliance Merchant Alta.
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

[QuestScript(60218)]
public class Quest60218Script : QuestScript
{
	protected override void Load()
	{
		SetId(60218);
		SetName("A Legend's Reality");
		SetDescription("Talk to Kedora Alliance Merchant Alta");

		AddPrerequisite(new LevelPrerequisite(320));
		AddPrerequisite(new CompletedPrerequisite("LSCAVE551_SQ_9"));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));
		AddReward(new ItemReward("Vis", 15040));

		AddDialogHook("LSCAVE551_ALTAR_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("LSCAVE551_ALTAR_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LSCAVE551_SQB_1_1", "LSCAVE551_SQB_1", "I'll try to find them", "I'll find it myself"))
		{
			case 1:
				await dialog.Msg("LSCAVE551_SQB_1_2");
				dialog.UnHideNPC("LSCAVE551_SQB_1_OBJ");
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

		await dialog.Msg("LSCAVE551_SQB_1_3");
		dialog.HideNPC("LSCAVE551_SQB_1_OBJ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

