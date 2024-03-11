//--- Melia Script -----------------------------------------------------------
// The Wizard and the Mage Tower (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with the Thaumaturge Master.
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

[QuestScript(19061)]
public class Quest19061Script : QuestScript
{
	protected override void Load()
	{
		SetId(19061);
		SetName("The Wizard and the Mage Tower (1)");
		SetDescription("Talk with the Thaumaturge Master");

		AddPrerequisite(new LevelPrerequisite(113));
		AddPrerequisite(new CompletedPrerequisite("FTOWER45_SQ_03"), new CompletedPrerequisite("FTOWER41_SQ_02"), new CompletedPrerequisite("FTOWER41_SQ_05"), new CompletedPrerequisite("FTOWER44_SQ_03"));

		AddDialogHook("JOB_THAUMATURGE3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER45_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FIRETOWER_45_HQ_01_ST", "FIRETOWER_45_HQ_01", "I'll make a bet", "Decline"))
		{
			case 1:
				await dialog.Msg("FIRETOWER_45_HQ_01_AC");
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

		await dialog.Msg("FIRETOWER_45_HQ_01_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

