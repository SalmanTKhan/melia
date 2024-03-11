//--- Melia Script -----------------------------------------------------------
// Supply Soldier's Favor (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Supply Soldier in the Eastern Woods.
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

[QuestScript(1042)]
public class Quest1042Script : QuestScript
{
	protected override void Load()
	{
		SetId(1042);
		SetName("Supply Soldier's Favor (2)");
		SetDescription("Talk to the Supply Soldier in the Eastern Woods");

		AddPrerequisite(new LevelPrerequisite(7));
		AddPrerequisite(new CompletedPrerequisite("SIAUL_EAST_REQUEST4"));

		AddObjective("kill0", "Kill 12 Pokubu(s)", new KillObjective(12, MonsterId.Pokubu));

		AddReward(new ExpReward(500, 500));
		AddReward(new ItemReward("expCard1", 1));
		AddReward(new ItemReward("Vis", 91));

		AddDialogHook("SIAUL_EAST_SOLDIER5", "BeforeStart", BeforeStart);
		AddDialogHook("SIAUL_EAST_SOLDIER5", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAUL_EAST_REQUEST5_dlg1", "SIAUL_EAST_REQUEST5", "I'll deal with the Pokubus", "Cancel"))
		{
			case 1:
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

		await dialog.Msg("SIAUL_EAST_REQUEST5_dlg3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

