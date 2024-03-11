//--- Melia Script -----------------------------------------------------------
// Do Not Enter
//--- Description -----------------------------------------------------------
// Quest to Talk with Soldier Rudolfas.
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

[QuestScript(8371)]
public class Quest8371Script : QuestScript
{
	protected override void Load()
	{
		SetId(8371);
		SetName("Do Not Enter");
		SetDescription("Talk with Soldier Rudolfas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "THORN22_ADD_SUB_02_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(120));

		AddObjective("kill0", "Kill 7 Meleech(s)", new KillObjective(7, MonsterId.Meleech));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3000));

		AddDialogHook("THORN22_ADD_SUB_02", "BeforeStart", BeforeStart);
		AddDialogHook("THORN22_ADD_SUB_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN22_ADD_SUB_02_select01", "THORN22_ADD_SUB_02", "Accept", "Cancel"))
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

		await dialog.Msg("THORN22_ADD_SUB_02_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

