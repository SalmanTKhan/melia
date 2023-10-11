//--- Melia Script -----------------------------------------------------------
// A New Attack (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Schaffenstar Adjutant Apollonius.
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

[QuestScript(72216)]
public class Quest72216Script : QuestScript
{
	protected override void Load()
	{
		SetId(72216);
		SetName("A New Attack (1)");
		SetDescription("Talk to Schaffenstar Adjutant Apollonius");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "CASTLE93_MAIN01_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(391));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("Vis", 20723));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("CASTLE93_NPC_MAIN01", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE93_NPC_MAIN01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE93_MAIN01_01", "CASTLE93_MAIN01", "I have to go do something else, sorry.", "Alright"))
		{
			case 1:
				// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
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

		await dialog.Msg("CASTLE93_MAIN01_02");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

