//--- Melia Script -----------------------------------------------------------
// Secure the Farmland
//--- Description -----------------------------------------------------------
// Quest to Soldier Dennis.
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

[QuestScript(50019)]
public class Quest50019Script : QuestScript
{
	protected override void Load()
	{
		SetId(50019);
		SetName("Secure the Farmland");
		SetDescription("Soldier Dennis");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SIAULIAI_50_1_SQ_120_TRACK", "SIAULIAI_50_1_SQ_120_prognpc01");

		AddPrerequisite(new LevelPrerequisite(71));
		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_50_1_SQ_110"));

		AddObjective("kill0", "Kill 1 Gorgon", new KillObjective(1, MonsterId.Boss_Gorgon));

		AddReward(new ExpReward(205740, 205740));
		AddReward(new ItemReward("expCard5", 5));
		AddReward(new ItemReward("Drug_SP2_Q", 15));
		AddReward(new ItemReward("Vis", 1349));

		AddDialogHook("SIAULIAI_50_1_SQ_SOLDIER01", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_50_1_SQ_SOLDIER01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_50_1_SQ_120_select01", "SIAULIAI_50_1_SQ_120", "I will look for the soldiers", "Tell him that it will be alright"))
		{
			case 1:
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

		await dialog.Msg("SIAULIAI_50_1_SQ_120_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

