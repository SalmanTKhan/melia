//--- Melia Script -----------------------------------------------------------
// Taking Down The Last Executive
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Stella.
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

[QuestScript(70608)]
public class Quest70608Script : QuestScript
{
	protected override void Load()
	{
		SetId(70608);
		SetName("Taking Down The Last Executive");
		SetDescription("Talk to Monk Stella");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "ABBEY41_6_SQ08_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(274));
		AddPrerequisite(new CompletedPrerequisite("ABBEY41_6_SQ07"));

		AddObjective("kill0", "Kill 1 Blue Riteris", new KillObjective(1, MonsterId.Boss_Riteris_Blue));

		AddReward(new ExpReward(2955183, 2955183));
		AddReward(new ItemReward("expCard12", 5));
		AddReward(new ItemReward("Vis", 11234));

		AddDialogHook("ABBEY416_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY416_SQ_08", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY416_SQ_08_start", "ABBEY41_6_SQ08", "Say that you it's time to finish this", "I'm not ready yet"))
		{
			case 1:
				dialog.HideNPC("ABBEY416_SQ_03");
				dialog.HideNPC("ABBEY416_SQ_08_1");
				dialog.HideNPC("ABBEY416_SQ_08_2");
				dialog.UnHideNPC("ABBEY416_SQ_08");
				dialog.UnHideNPC("ABBEY416_SQ_09_1");
				dialog.UnHideNPC("ABBEY416_SQ_09_2");
				dialog.UnHideNPC("ABBEY416_SQ_09_3");
				dialog.UnHideNPC("ABBEY416_SQ_09_4");
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

		await dialog.Msg("ABBEY416_SQ_08_succ");
		dialog.HideNPC("PILGRIM415_SQ_08_1");
		dialog.HideNPC("PILGRIM415_SQ_06");
		dialog.UnHideNPC("PILGRIM415_SQ_06_2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

