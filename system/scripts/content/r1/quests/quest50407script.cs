//--- Melia Script -----------------------------------------------------------
// The City Under Threat (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Wizard Nidia.
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

[QuestScript(50407)]
public class Quest50407Script : QuestScript
{
	protected override void Load()
	{
		SetId(50407);
		SetName("The City Under Threat (1)");
		SetDescription("Talk to Wizard Nidia");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_NICOPOLIS_81_3_SQ_04_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(387));
		AddPrerequisite(new CompletedPrerequisite("F_NICOPOLIS_81_3_SQ_04"));
		AddPrerequisite(new ItemPrerequisite("NICOPOLIS_813_SUBQ043_ITEM1", -100));

		AddObjective("kill0", "Kill 6 Slime Wizard(s) or Slime Witch(s)", new KillObjective(6, 59161, 59151));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 31000));

		AddDialogHook("NICO813_SUBQ_NPC2_2", "BeforeStart", BeforeStart);
		AddDialogHook("NICO813_SUBQ_NPC3_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("NICO813_SUBQ05_START1", "F_NICOPOLIS_81_3_SQ_05", "I'll go and have a look.", "Don't worry."))
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

		await dialog.Msg("NICO813_SUBQ05_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

