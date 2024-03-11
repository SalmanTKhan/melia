//--- Melia Script -----------------------------------------------------------
// Statue Maintenance [Dievdirbys Advancement] (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Krivis Master.
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

[QuestScript(17440)]
public class Quest17440Script : QuestScript
{
	protected override void Load()
	{
		SetId(17440);
		SetName("Statue Maintenance [Dievdirbys Advancement] (3)");
		SetDescription("Talk to the Krivis Master");

		AddPrerequisite(new LevelPrerequisite(135));
		AddPrerequisite(new CompletedPrerequisite("JOB_DIEVDIRBYS4_2"));

		AddReward(new ItemReward("JOB_DIEVDIRBYS4_1_ITEM", 1));

		AddDialogHook("MASTER_KRIWI", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_PRIEST", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_DIEVDIRBYS4_3_ST", "JOB_DIEVDIRBYS4_3", "I'll go to the Priest Master", "Quit"))
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

		await dialog.Msg("JOB_DIEVDIRBYS4_3_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("JOB_DIEVDIRBYS4_4");
	}
}

