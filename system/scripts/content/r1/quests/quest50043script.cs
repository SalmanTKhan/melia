//--- Melia Script -----------------------------------------------------------
// Big Accident
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sorcerer Master.
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

[QuestScript(50043)]
public class Quest50043Script : QuestScript
{
	protected override void Load()
	{
		SetId(50043);
		SetName("Big Accident");
		SetDescription("Talk to the Sorcerer Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PARTY_Q_090_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(100));

		AddObjective("kill0", "Kill 1 Magic Square of Thorn Forest", new KillObjective(1, MonsterId.Magicsquare_1));

		AddDialogHook("JOB_SORCERER4_1", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_SORCERER4_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PARTY_Q_090_statnpc01", "PARTY_Q_090", "I'll help you", "I have many things to do"))
		{
			case 1:
				dialog.UnHideNPC("PARTY_Q9_TRIGGER");
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

		await dialog.Msg("PARTY_Q_090_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

