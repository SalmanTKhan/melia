//--- Melia Script -----------------------------------------------------------
// The Corrupted Lake (4)
//--- Description -----------------------------------------------------------
// Quest to Deliver the diary to the Elder's Granddaughter.
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

[QuestScript(90003)]
public class Quest90003Script : QuestScript
{
	protected override void Load()
	{
		SetId(90003);
		SetName("The Corrupted Lake (4)");
		SetDescription("Deliver the diary to the Elder's Granddaughter");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_3CMLAKE_83_MQ_03_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_83_MQ_02"));
		AddPrerequisite(new ItemPrerequisite("F_3CMLAKE_83_MQ_ITEM3", 1));

		AddObjective("kill0", "Kill 6 Rajatadpole(s)", new KillObjective(6, MonsterId.Rajatadpole));

		AddReward(new ExpReward(368565, 368565));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1235));

		AddDialogHook("3CMLAKE_83_LADY", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_83_OLDMAN3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("3CMLAKE_83_MQ_03_DLG_01", "F_3CMLAKE_83_MQ_03", "I'll find the village chief", "Wait a minute."))
		{
			case 1:
				await dialog.Msg("3CMLAKE_83_MQ_03_DLG_AG");
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


		return HookResult.Break;
	}
}

