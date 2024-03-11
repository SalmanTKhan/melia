//--- Melia Script -----------------------------------------------------------
// Trouble at the Warehouse
//--- Description -----------------------------------------------------------
// Quest to Talk to Wizard Rimas.
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

[QuestScript(40230)]
public class Quest40230Script : QuestScript
{
	protected override void Load()
	{
		SetId(40230);
		SetName("Trouble at the Warehouse");
		SetDescription("Talk to Wizard Rimas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FARM47_3_SQ_060_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(86));
		AddPrerequisite(new CompletedPrerequisite("FARM47_3_SQ_050"));

		AddObjective("kill0", "Kill 20 Farm Keposeed(s) or Farm Ellum(s) or Orange Dandel(s) or Ashrong(s) or White Operor(s)", new KillObjective(20, 57503, 57502, 57327, 57488, 57330));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 1720));

		AddDialogHook("FARM47_RIMAS", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_RIMAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM47_3_SQ_060_ST", "FARM47_3_SQ_060", "I will protect the storage", "About the relationship between the power generator and the grains", "Decline"))
		{
			case 1:
				await dialog.Msg("FARM47_3_SQ_060_AC");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
			case 2:
				await dialog.Msg("FARM47_3_SQ_060_ADD");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FARM47_3_SQ_060_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

