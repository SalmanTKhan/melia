//--- Melia Script -----------------------------------------------------------
// The Feline Post Town Case (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Auguste Dupin.
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

[QuestScript(50387)]
public class Quest50387Script : QuestScript
{
	protected override void Load()
	{
		SetId(50387);
		SetName("The Feline Post Town Case (1)");
		SetDescription("Talk to Auguste Dupin");

		AddPrerequisite(new LevelPrerequisite(384));

		AddDialogHook("NICO812_SUBQ_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("NICO812_SUBQ_NPC4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("NICOPOLIS812_SQ01_START1", "F_NICOPOLIS_81_2_SQ_01", "I will help you.", "I wish you good luck."))
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

		await dialog.Msg("NICOPOLIS812_SQ01_SUCC2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

