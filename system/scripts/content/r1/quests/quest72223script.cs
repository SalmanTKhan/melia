//--- Melia Script -----------------------------------------------------------
// The Unfortunate Cursed Land
//--- Description -----------------------------------------------------------
// Quest to Talk to the Wounded Soldier Spirit.
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

[QuestScript(72223)]
public class Quest72223Script : QuestScript
{
	protected override void Load()
	{
		SetId(72223);
		SetName("The Unfortunate Cursed Land");
		SetDescription("Talk to the Wounded Soldier Spirit");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "CASTLE94_MAIN01_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(394));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("Vis", 20882));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("CASTLE94_NPC_MAIN01", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE94_NPC_MAIN01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE94_MAIN01_01", "CASTLE94_MAIN01", "What's going on?", "I, uh, gotta go. Bye!"))
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

		await dialog.Msg("CASTLE94_MAIN01_02");
		// Func/SCR_CASTLE94_MAIN01_END;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

