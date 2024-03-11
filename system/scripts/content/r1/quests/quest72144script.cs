//--- Melia Script -----------------------------------------------------------
// Disturbance of the Winged Beast (1)
//--- Description -----------------------------------------------------------
// Quest to Find the Peltasta Master.
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

[QuestScript(72144)]
public class Quest72144Script : QuestScript
{
	protected override void Load()
	{
		SetId(72144);
		SetName("Disturbance of the Winged Beast (1)");
		SetDescription("Find the Peltasta Master");

		AddPrerequisite(new LevelPrerequisite(135));
		AddPrerequisite(new CompletedPrerequisite("MASTER_PELTASTA1_2"));

		AddDialogHook("MASTER_PELTASTA", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_HIGHLANDER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MASTER_PELTASTA2_1_DLG1", "MASTER_PELTASTA2_1", "I accept the request", "I'll wait a little bit"))
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

		await dialog.Msg("JOB_PELTASTA4_1_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("MASTER_PELTASTA2_2");
	}
}

