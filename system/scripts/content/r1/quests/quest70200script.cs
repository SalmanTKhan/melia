//--- Melia Script -----------------------------------------------------------
// Missing Soldier
//--- Description -----------------------------------------------------------
// Quest to Talk with Mesafasla Assistant Commander Gorman.
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

[QuestScript(70200)]
public class Quest70200Script : QuestScript
{
	protected override void Load()
	{
		SetId(70200);
		SetName("Missing Soldier");
		SetDescription("Talk with Mesafasla Assistant Commander Gorman");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "TABLELAND28_1_SQ01_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(212));

		AddObjective("kill0", "Kill 6 Green Lepusbunny(s) or Red Saltisdaughter Magician(s)", new KillObjective(6, 57889, 57938));

		AddReward(new ExpReward(1082046, 1082046));
		AddReward(new ItemReward("expCard11", 4));
		AddReward(new ItemReward("Vis", 7420));

		AddDialogHook("TABLELAND281_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("TABLELAND281_SQ_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND28_1_SQ_01_1", "TABLELAND28_1_SQ01", "Sure, I'll help", "Decline"))
		{
			case 1:
				await dialog.Msg("TABLELAND28_1_SQ_01_2");
				dialog.UnHideNPC("TABLELAND281_SQ_02");
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

		await dialog.Msg("TABLELAND28_1_SQ_01_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

