//--- Melia Script -----------------------------------------------------------
// Aras' Commission (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Operations Officer.
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

[QuestScript(1039)]
public class Quest1039Script : QuestScript
{
	protected override void Load()
	{
		SetId(1039);
		SetName("Aras' Commission (2)");
		SetDescription("Talk to the Operations Officer");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SIAUL_EAST_REQUEST2_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(7));
		AddPrerequisite(new CompletedPrerequisite("SIAUL_EAST_REQUEST1"));

		AddObjective("kill0", "Kill 8 Vubbe Miner(s) or Popolion(s) or Vubbe Scout(s) or Vubbe Scout(s)", new KillObjective(8, 11125, 400981, 57192, 57260));

		AddReward(new ExpReward(3000, 3000));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 7));
		AddReward(new ItemReward("Vis", 91));

		AddDialogHook("SIAUL_EAST_SUPPLY_MANAGER2", "BeforeStart", BeforeStart);
		AddDialogHook("SIAUL_EAST_SUPPLY_MANAGER2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAUL_EAST_REQUEST2_dlg1", "SIAUL_EAST_REQUEST2", "I'll take a look", "About the Vubbes", "I think you should take care of it yourself"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
			case 2:
				await dialog.Msg("SIAUL_EAST_REQUEST2_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("SIAUL_EAST_REQUEST2_dlg3");
		dialog.UnHideNPC("SIAUL_EAST_SOLDIER8");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

