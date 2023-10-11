//--- Melia Script -----------------------------------------------------------
// False Scriptures
//--- Description -----------------------------------------------------------
// Quest to Talk to Elgos Monk.
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

[QuestScript(80088)]
public class Quest80088Script : QuestScript
{
	protected override void Load()
	{
		SetId(80088);
		SetName("False Scriptures");
		SetDescription("Talk to Elgos Monk");

		AddPrerequisite(new LevelPrerequisite(229));
		AddPrerequisite(new CompletedPrerequisite("ABBEY_35_4_SQ_8"));

		AddReward(new ExpReward(541023, 541023));
		AddReward(new ItemReward("expCard11", 1));
		AddReward(new ItemReward("Vis", 8244));

		AddDialogHook("ABBEY_35_3_MONK", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY_35_3_MONK", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY_35_3_SQ_11_start", "ABBEY_35_3_SQ_11", "I'll try to find them", "I'm busy now"))
		{
			case 1:
				dialog.UnHideNPC("ABBEY_35_3_SQ_11_EVILBILE");
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

		await dialog.Msg("ABBEY_35_3_SQ_11_succ");
		dialog.HideNPC("ABBEY_35_3_SQ_11_EVILBILE");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

