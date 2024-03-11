//--- Melia Script -----------------------------------------------------------
// The Bishop's Dream of the Revelation
//--- Description -----------------------------------------------------------
// Quest to Talk to Knight Commander Uska.
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

[QuestScript(1027)]
public class Quest1027Script : QuestScript
{
	protected override void Load()
	{
		SetId(1027);
		SetName("The Bishop's Dream of the Revelation");
		SetDescription("Talk to Knight Commander Uska");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ItemReward("Scroll_Warp_Klaipe", 5));

		AddDialogHook("KLAPEDA_USKA", "BeforeStart", BeforeStart);
		AddDialogHook("KLAPEDA_USKA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KLAPEDA_GO_TO_EAST_dlg1", "KLAPEDA_GO_TO_EAST", "I have come with the revelation", "Cancel"))
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

		await dialog.Msg("KLAPEDA_GO_TO_EAST_dlg3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

