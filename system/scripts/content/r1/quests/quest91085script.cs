//--- Melia Script -----------------------------------------------------------
// To the combat
//--- Description -----------------------------------------------------------
// Quest to Find the Lord of Orsha Inesa Hamondale.
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

[QuestScript(91085)]
public class Quest91085Script : QuestScript
{
	protected override void Load()
	{
		SetId(91085);
		SetName("To the combat");
		SetDescription("Find the Lord of Orsha Inesa Hamondale");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP14_1_FCASTLE1_MQ_1_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(460));

		AddObjective("kill0", "Kill 10 Blickferret Spearman(s) or Blickferret Charger(s)", new KillObjective(10, 59692, 59693));

		AddReward(new ExpReward(1046153856, 1046153856));
		AddReward(new ItemReward("Vis", 28980));

		AddDialogHook("C_ORSHA_HAMONDAIL", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_1_F_CASTLE_1_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_1_FCASTLE1_MQ_1_SNPC_DLG1", "EP14_1_FCASTLE1_MQ_1", "I'll join right away", "That's too difficult to do now"))
		{
			case 1:
				await dialog.Msg("EP14_1_FCASTLE1_MQ_1_SNPC_DLG2");
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

		await dialog.Msg("EP14_1_FCASTLE1_MQ_1_CNPC_DLG1");
		dialog.HideNPC("EP14_1_F_CASTLE_1_NPC2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

