//--- Melia Script -----------------------------------------------------------
// The Sculpture in Represijos Street
//--- Description -----------------------------------------------------------
// Quest to Talk to Owynia Dilben.
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

[QuestScript(50381)]
public class Quest50381Script : QuestScript
{
	protected override void Load()
	{
		SetId(50381);
		SetName("The Sculpture in Represijos Street");
		SetDescription("Talk to Owynia Dilben");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_NICOPOLIS_81_1_SQ_03_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(381));
		AddPrerequisite(new CompletedPrerequisite("F_NICOPOLIS_81_1_SQ_02"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 23000));

		AddDialogHook("NICO811_NPC1_2", "BeforeStart", BeforeStart);
		AddDialogHook("NICO811_NPC1_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("NICO811_SUBQ3_START", "F_NICOPOLIS_81_1_SQ_03", "I'll do it. There may be monsters about.", "Let's do this later."))
		{
			case 1:
				await dialog.Msg("NICO811_SUBQ3_AGREE1");
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

		await dialog.Msg("NICO811_SUBQ3_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

