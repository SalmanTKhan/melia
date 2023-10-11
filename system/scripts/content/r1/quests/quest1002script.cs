//--- Melia Script -----------------------------------------------------------
// Talk to Knight Titas (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Knight Titas.
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

[QuestScript(1002)]
public class Quest1002Script : QuestScript
{
	protected override void Load()
	{
		SetId(1002);
		SetName("Talk to Knight Titas (2)");
		SetDescription("Talk to Knight Titas");

		AddPrerequisite(new LevelPrerequisite(1));
		AddPrerequisite(new CompletedPrerequisite("SIAUL_WEST_MEET_TITAS"));

		AddReward(new ItemReward("Drug_HP1_Q", 3));

		AddDialogHook("SIAUL_WEST_CAMP_MANAGER", "BeforeStart", BeforeStart);
		AddDialogHook("SIAUL_WEST_CAMP_MANAGER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAUL_WEST_WEST_FOREST_dlg1", "SIAUL_WEST_WEST_FOREST", "Alright, I will tell the troops to assemble", "Decline"))
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

		await dialog.Msg("SIAUL_WEST_WEST_FOREST_dlg4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

