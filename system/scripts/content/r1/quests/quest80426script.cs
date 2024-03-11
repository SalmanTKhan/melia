//--- Melia Script -----------------------------------------------------------
// Kartas Appears (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Ilona.
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

[QuestScript(80426)]
public class Quest80426Script : QuestScript
{
	protected override void Load()
	{
		SetId(80426);
		SetName("Kartas Appears (2)");
		SetDescription("Talk to Kupole Ilona");
		SetTrack(QuestStatus.Possible, QuestStatus.Possible, "F_MAPLE_24_1_MQ_06_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(411));
		AddPrerequisite(new CompletedPrerequisite("F_MAPLE_24_1_MQ_05"));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("F_MAPLE_241_MQ_06_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("F_MAPLE_241_MQ_06_NPC2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FadeOutIN/2000");
		dialog.HideNPC("F_MAPLE_241_MQ_06_NPC2");
		dialog.UnHideNPC("F_MAPLE_242_MQ_01_NPC");
		// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

