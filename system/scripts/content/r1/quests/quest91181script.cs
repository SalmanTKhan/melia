//--- Melia Script -----------------------------------------------------------
// Into the Oratory
//--- Description -----------------------------------------------------------
// Quest to Talk to Edmundas.
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

[QuestScript(91181)]
public class Quest91181Script : QuestScript
{
	protected override void Load()
	{
		SetId(91181);
		SetName("Into the Oratory");
		SetDescription("Talk to Edmundas");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "EP15_1_F_ABBEY2_8_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(485));
		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY2_7"));

		AddReward(new ExpReward(1800000000, 1800000000));
		AddReward(new ItemReward("Vis", 41379));

		AddDialogHook("EP15_1_FABBEY2_AD2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("EP15_1_F_ABBEY2_8_DLG4");
		await dialog.Msg("FadeOutIN/2000");
		dialog.HideNPC("EP15_1_FABBEY2_AD2");
		// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

