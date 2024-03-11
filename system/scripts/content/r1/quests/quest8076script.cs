//--- Melia Script -----------------------------------------------------------
// Healer Lady's Worry (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Healer Lady.
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

[QuestScript(8076)]
public class Quest8076Script : QuestScript
{
	protected override void Load()
	{
		SetId(8076);
		SetName("Healer Lady's Worry (2)");
		SetDescription("Talk to the Healer Lady");

		AddPrerequisite(new LevelPrerequisite(9));
		AddPrerequisite(new CompletedPrerequisite("SOUT_Q_09"));

		AddObjective("kill0", "Kill 11 Jukopus(s) or Vubbe Thief(s) or Red Kepa(s) or Vubbe Scout(s)", new KillObjective(11, 400061, 11120, 400003, 57192));

		AddReward(new ExpReward(500, 500));
		AddReward(new ItemReward("expCard1", 1));
		AddReward(new ItemReward("LEG01_117", 1));
		AddReward(new ItemReward("TOP01_117", 1));
		AddReward(new ItemReward("Vis", 117));

		AddDialogHook("SIAULIAIOUT_HEALER_C", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAIOUT_HEALER_B", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SOUT_Q_10_1", "SOUT_Q_10", "I'll defeat the menacing monsters", "Decline"))
		{
			case 1:
				dialog.UnHideNPC("SIAULIAIOUT_HEALER_B");
				dialog.HideNPC("SIAULIAIOUT_HEALER_C");
				dialog.UnHideNPC("SIAULIAIOUT_RETUA");
				dialog.UnHideNPC("MASTER_CLERIC");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("SOUT_Q_10_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

