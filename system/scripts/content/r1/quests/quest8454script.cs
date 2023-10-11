//--- Melia Script -----------------------------------------------------------
// Old Story (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Coben.
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

[QuestScript(8454)]
public class Quest8454Script : QuestScript
{
	protected override void Load()
	{
		SetId(8454);
		SetName("Old Story (3)");
		SetDescription("Talk to Coben");

		AddPrerequisite(new LevelPrerequisite(107));
		AddPrerequisite(new CompletedPrerequisite("REMAINS40_MQ_02"));

		AddReward(new ExpReward(122855, 122855));
		AddReward(new ItemReward("expCard6", 1));
		AddReward(new ItemReward("Vis", 2568));

		AddDialogHook("REMAINS_40_DRUNK_01", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS_40_DRUNK_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAINS40_MQ_03_01", "REMAINS40_MQ_03", "I'll go and read the tombstone", "Decline"))
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

		await dialog.Msg("REMAINS40_MQ_03_03");
		await dialog.Msg("FadeOutIN/3000");
		dialog.UnHideNPC("REMAINS_40_DRUNK_02");
		dialog.HideNPC("REMAINS_40_DRUNK_01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

