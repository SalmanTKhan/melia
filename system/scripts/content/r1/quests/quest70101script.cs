//--- Melia Script -----------------------------------------------------------
// Trouble at the Tyla Monastery
//--- Description -----------------------------------------------------------
// Quest to Talk to Hunter Tracker Capt. Mintz.
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

[QuestScript(70101)]
public class Quest70101Script : QuestScript
{
	protected override void Load()
	{
		SetId(70101);
		SetName("Trouble at the Tyla Monastery");
		SetDescription("Talk to Hunter Tracker Capt. Mintz");

		AddPrerequisite(new LevelPrerequisite(173));
		AddPrerequisite(new CompletedPrerequisite("THORN39_2_MQ01"));

		AddDialogHook("THORN392_MQ_02", "BeforeStart", BeforeStart);
		AddDialogHook("THORN392_MQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN39_2_MQ_02_1", "THORN39_2_MQ02", "Tell him that you would help", "About Ebonypawn", "Tell him that you are not completely healed yet"))
		{
			case 1:
				await dialog.Msg("THORN39_2_MQ_02_2");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("THORN39_2_MQ_02_5");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("THORN39_2_MQ_02_4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

