//--- Melia Script -----------------------------------------------------------
// The Nobreer Epidemic
//--- Description -----------------------------------------------------------
// Quest to Talk to Plague Doctor Jugrinas.
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

[QuestScript(30274)]
public class Quest30274Script : QuestScript
{
	protected override void Load()
	{
		SetId(30274);
		SetName("The Nobreer Epidemic");
		SetDescription("Talk to Plague Doctor Jugrinas");

		AddPrerequisite(new LevelPrerequisite(322));

		AddDialogHook("WTREES_21_2_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("WTREES_21_2_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WTREES_21_2_SQ_1_select", "WTREES_21_2_SQ_1", "Alright, I'll take your medicine.", "That's absolute nonsense."))
		{
			case 1:
				await dialog.Msg("WTREES_21_2_SQ_1_agree");
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

		await dialog.Msg("WTREES_21_2_SQ_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

