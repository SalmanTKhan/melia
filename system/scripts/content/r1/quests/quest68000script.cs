//--- Melia Script -----------------------------------------------------------
// Boruta
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Kaze.
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

[QuestScript(68000)]
public class Quest68000Script : QuestScript
{
	protected override void Load()
	{
		SetId(68000);
		SetName("Boruta");
		SetDescription("Talk to Kupole Kaze");

		AddPrerequisite(new LevelPrerequisite(360));

		AddReward(new ItemReward("RVR_BK_KEYITEM_URVAS_1", 1));
		AddReward(new ItemReward("ABOUT_BORUTA_BOOK", 1));

		AddDialogHook("RVR_BK_KAZE_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("RVR_BK_KAZE_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("RVR_BK_TUTORIAL_1_1", "RVR_BK_TUTORIAL_1", "I'll go there", "That's too much"))
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

		// Func/SCR_GIVE_EMBLEM_KAZE;
		dialog.ShowHelp("TUTO_SEAL_REINFORCE;Tuto");
		await dialog.Msg("RVR_BK_TUTORIAL_1_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

