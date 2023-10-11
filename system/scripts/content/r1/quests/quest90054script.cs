//--- Melia Script -----------------------------------------------------------
// For Safety (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Dievdirbys Aisol.
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

[QuestScript(90054)]
public class Quest90054Script : QuestScript
{
	protected override void Load()
	{
		SetId(90054);
		SetName("For Safety (2)");
		SetDescription("Talk to Dievdirbys Aisol");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "KATYN_45_2_SQ_13_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(249));
		AddPrerequisite(new CompletedPrerequisite("KATYN_45_2_SQ_12"));

		AddObjective("kill0", "Kill 1 Sequoia", new KillObjective(1, MonsterId.Boss_Sequoia_Q2));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 9213));

		AddDialogHook("KATYN_45_2_ESOL", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_2_ESOL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_45_2_SQ_13_ST", "KATYN_45_2_SQ_13", "Don't worry", "I will think about it"))
		{
			case 1:
				await dialog.Msg("KATYN_45_2_SQ_13_AG");
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

		await dialog.Msg("KATYN_45_2_SQ_13_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

