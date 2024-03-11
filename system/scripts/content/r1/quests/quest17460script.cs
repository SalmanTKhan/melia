//--- Melia Script -----------------------------------------------------------
// Statue Maintenance [Dievdirbys Advancement] (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Bokor Master.
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

[QuestScript(17460)]
public class Quest17460Script : QuestScript
{
	protected override void Load()
	{
		SetId(17460);
		SetName("Statue Maintenance [Dievdirbys Advancement] (5)");
		SetDescription("Talk to the Bokor Master");

		AddPrerequisite(new LevelPrerequisite(135));
		AddPrerequisite(new CompletedPrerequisite("JOB_DIEVDIRBYS4_4"));

		AddDialogHook("MASTER_BOCORS", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_DIEVDIRBYS2_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_DIEVDIRBYS4_5_ST", "JOB_DIEVDIRBYS4_5", "I will go and take care of the Goddess Statue", "Give me some time to prepare"))
		{
			case 1:
				await dialog.Msg("JOB_DIEVDIRBYS4_5_PRST");
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

		await dialog.Msg("JOB_DIEVDIRBYS4_5_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

