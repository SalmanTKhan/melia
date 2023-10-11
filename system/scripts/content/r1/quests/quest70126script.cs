//--- Melia Script -----------------------------------------------------------
// Interim Report
//--- Description -----------------------------------------------------------
// Quest to Talk to Senior Monk Marko.
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

[QuestScript(70126)]
public class Quest70126Script : QuestScript
{
	protected override void Load()
	{
		SetId(70126);
		SetName("Interim Report");
		SetDescription("Talk to Senior Monk Marko");

		AddPrerequisite(new LevelPrerequisite(176));
		AddPrerequisite(new CompletedPrerequisite("THORN39_1_MQ06"));

		AddDialogHook("THORN391_MQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("THORN392_MQ_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN39_1_MQ_07_1", "THORN39_1_MQ07"))
		{
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("THORN39_1_MQ_07_4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

