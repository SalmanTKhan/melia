//--- Melia Script -----------------------------------------------------------
// Pharmacist's Favor (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Pharmacist Lady.
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

[QuestScript(40050)]
public class Quest40050Script : QuestScript
{
	protected override void Load()
	{
		SetId(40050);
		SetName("Pharmacist's Favor (1)");
		SetDescription("Talk to the Pharmacist Lady");

		AddPrerequisite(new LevelPrerequisite(11));
		AddPrerequisite(new CompletedPrerequisite("SOUT_Q_16"), new CompletedPrerequisite("SOUT_Q_08"), new CompletedPrerequisite("SOUT_SUDD_PREBOSS"), new CompletedPrerequisite("SOUT_Q_05"));

		AddDialogHook("SOUT_PHARMACY", "BeforeStart", BeforeStart);
		AddDialogHook("SOUT_PHARMACY", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SOUT_Q_20_ST", "SOUT_Q_20", "OK, I'll give you some", "Decline"))
		{
			case 1:
				await dialog.Msg("SOUT_Q_20_AC");
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

		await dialog.Msg("SOUT_Q_20_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

