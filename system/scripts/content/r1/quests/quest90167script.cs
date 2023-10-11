//--- Melia Script -----------------------------------------------------------
// Interview - Fencer Master (1)
//--- Description -----------------------------------------------------------
// Quest to Deliver the Letter to the Fencer Master.
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

[QuestScript(90167)]
public class Quest90167Script : QuestScript
{
	protected override void Load()
	{
		SetId(90167);
		SetName("Interview - Fencer Master (1)");
		SetDescription("Deliver the Letter to the Fencer Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "LOWLV_MASTER_SQ_30_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(290));
		AddPrerequisite(new CompletedPrerequisite("LOWLV_MASTER_ENCY_SQ_10"));
		AddPrerequisite(new ItemPrerequisite("LOWLV_MASTER_ENCY_SQ_10_ITEM1", -100));

		AddObjective("kill0", "Kill 4 Catacombs Leaf Bug(s)", new KillObjective(4, MonsterId.Leaf_Diving_Purple_Q1));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("misc_ore17", 1));
		AddReward(new ItemReward("Vis", 12180));

		AddDialogHook("MASTER_FENCER", "BeforeStart", BeforeStart);
		AddDialogHook("LOWLV_MASTER_ENCY_SQ_30_BOOK", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LOWLV_MASTER_ENCY_SQ_30_ST", "LOWLV_MASTER_ENCY_SQ_30", "Hand the Letter from the Sage Master", "Oh, it's nothing"))
		{
			case 1:
				await dialog.Msg("LOWLV_MASTER_ENCY_SQ_30_AU");
				dialog.UnHideNPC("LOWLV_MASTER_ENCY_SQ_30_BOOK");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

