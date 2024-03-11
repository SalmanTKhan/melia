//--- Melia Script -----------------------------------------------------------
// Welcomed One (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Assistant Commander Talon.
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

[QuestScript(50148)]
public class Quest50148Script : QuestScript
{
	protected override void Load()
	{
		SetId(50148);
		SetName("Welcomed One (3)");
		SetDescription("Talk to Assistant Commander Talon");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "TABLELAND_70_SQ3_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(238));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_70_SQ2"));

		AddObjective("kill0", "Kill 10 Blue Hohen Mage(s) or Blue Hohen Mane(s) or Blue Lapasape Shaman(s)", new KillObjective(10, 57973, 57967, 57945));

		AddReward(new ExpReward(5910366, 5910366));
		AddReward(new ItemReward("expCard12", 2));
		AddReward(new ItemReward("Vis", 8568));

		AddDialogHook("TABLE70_CAPTIN1_1", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE70_CAPTIN1_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_70_SQ3_startnpc01", "TABLELAND_70_SQ3", "Alright", "Thank you, this is enough."))
		{
			case 1:
				await dialog.Msg("TABLELAND_70_SQ3_startnpc02");
				dialog.HideNPC("TABLE70_SOLDIER7_1");
				dialog.UnHideNPC("TABLE70_SOLDIER2_2");
				dialog.UnHideNPC("TABLE70_SUBQ3_BOX");
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

		await dialog.Msg("TABLELAND_70_SQ3_succ01");
		// Func/TABLELAND70_SUBQ4_HIDE;
		// Func/TABLELAND70_SUBQ4_UNHIDE;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

