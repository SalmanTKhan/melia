//--- Melia Script -----------------------------------------------------------
// Finding the Model [Dievdirbys Advancement] (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Sculptor Tesla.
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

[QuestScript(1129)]
public class Quest1129Script : QuestScript
{
	protected override void Load()
	{
		SetId(1129);
		SetName("Finding the Model [Dievdirbys Advancement] (1)");
		SetDescription("Talk to Sculptor Tesla");

		AddPrerequisite(new LevelPrerequisite(85));

		AddDialogHook("JOB_DIEVDIRBYS2_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("EMILIA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_DIEVDIRBYS3_1_select1", "JOB_DIEVDIRBYS3_1", "I'll bring you a cat", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_DIEVDIRBYS3_1_AG");
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

		await dialog.Msg("JOB_DIEVDIRBYS3_1_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("JOB_DIEVDIRBYS3_2");
	}
}

