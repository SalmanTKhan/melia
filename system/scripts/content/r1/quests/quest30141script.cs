//--- Melia Script -----------------------------------------------------------
// True Nature of Sarma's Research (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Sarma.
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

[QuestScript(30141)]
public class Quest30141Script : QuestScript
{
	protected override void Load()
	{
		SetId(30141);
		SetName("True Nature of Sarma's Research (2)");
		SetDescription("Talk with Sarma");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ORCHARD_34_1_SQ_12_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(220));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_34_1_SQ_11"));

		AddObjective("kill0", "Kill 5 Green Eldigo(s)", new KillObjective(5, MonsterId.Eldigo_Green));

		AddReward(new ExpReward(3246138, 3246138));
		AddReward(new ItemReward("expCard11", 2));
		AddReward(new ItemReward("Vis", 95040));

		AddDialogHook("ORCHARD_34_1_SQ_NPC_2_2", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD_34_1_SQ_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORCHARD_34_1_SQ_12_select", "ORCHARD_34_1_SQ_12", "I will try", "That is not needed"))
		{
			case 1:
				await dialog.Msg("ORCHARD_34_1_SQ_12_agree");
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

		await dialog.Msg("ORCHARD_34_1_SQ_12_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

