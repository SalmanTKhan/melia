//--- Melia Script -----------------------------------------------------------
// Negotiator
//--- Description -----------------------------------------------------------
// Quest to Talk to Refugee Mylija.
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

[QuestScript(70822)]
public class Quest70822Script : QuestScript
{
	protected override void Load()
	{
		SetId(70822);
		SetName("Negotiator");
		SetDescription("Talk to Refugee Mylija");

		AddPrerequisite(new LevelPrerequisite(319));
		AddPrerequisite(new CompletedPrerequisite("MAPLE23_2_SQ01"), new CompletedPrerequisite("MAPLE23_2_SQ02"));

		AddDialogHook("MAPLE232_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE232_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MAPLE232_SQ_03_start", "MAPLE23_2_SQ03", "Say that you will try to do so", "Say that you are not feeling too confident"))
		{
			case 1:
				await dialog.Msg("MAPLE232_SQ_03_agree");
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

		await dialog.Msg("MAPLE232_SQ_03_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

