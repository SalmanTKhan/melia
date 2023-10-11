//--- Melia Script -----------------------------------------------------------
// The hidden treasures(1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Coben.
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

[QuestScript(50041)]
public class Quest50041Script : QuestScript
{
	protected override void Load()
	{
		SetId(50041);
		SetName("The hidden treasures(1)");
		SetDescription("Talk to Coben");

		AddPrerequisite(new LevelPrerequisite(100));

		AddDialogHook("REMAINS_40_DRUNK_03", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS_40_DRUNK_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PARTY_Q_080_startnpc01", "PARTY_Q_080", "Ask him to tell you how to use it since you are interested", "Tell him you don't need it"))
		{
			case 1:
				await dialog.Msg("PARTY_Q_080_startnpc02");
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

		await dialog.Msg("PARTY_Q_080_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

