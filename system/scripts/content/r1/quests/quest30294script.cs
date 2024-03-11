//--- Melia Script -----------------------------------------------------------
// A Story of Demons and Goddesses (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Lenja.
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

[QuestScript(30294)]
public class Quest30294Script : QuestScript
{
	protected override void Load()
	{
		SetId(30294);
		SetName("A Story of Demons and Goddesses (3)");
		SetDescription("Talk to Kupole Lenja");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "WTREES_21_1_SQ_11_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(325));
		AddPrerequisite(new CompletedPrerequisite("WTREES_21_1_SQ_10"));

		AddReward(new ItemReward("WTREES_21_1_SQ_6_ITEM_C", 1));
		AddReward(new ItemReward("WTREES_21_1_SQ_8_ITEM_C", 1));
		AddReward(new ItemReward("WTREES_21_1_SQ_10_ITEM_C", 1));
		AddReward(new ItemReward("COLLECT_307", 1));

		AddDialogHook("WTREES_21_1_NPC_1_AFTER", "BeforeStart", BeforeStart);
		AddDialogHook("WTREES_21_1_NPC_1_AFTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WTREES_21_1_SQ_11_select", "WTREES_21_1_SQ_11", "I will go and see the treaty now.", "I need to prepare myself"))
		{
			case 1:
				await dialog.Msg("WTREES_21_1_SQ_11_agree");
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

		await dialog.Msg("WTREES_21_1_SQ_11_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

