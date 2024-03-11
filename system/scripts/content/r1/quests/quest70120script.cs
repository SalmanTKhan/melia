//--- Melia Script -----------------------------------------------------------
// Not A Chance
//--- Description -----------------------------------------------------------
// Quest to Talk to Hunter Natasha.
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

[QuestScript(70120)]
public class Quest70120Script : QuestScript
{
	protected override void Load()
	{
		SetId(70120);
		SetName("Not A Chance");
		SetDescription("Talk to Hunter Natasha");

		AddPrerequisite(new LevelPrerequisite(176));
		AddPrerequisite(new CompletedPrerequisite("THORN39_2_MQ06"));

		AddDialogHook("THORN391_MQ_04", "BeforeStart", BeforeStart);
		AddDialogHook("THORN391_MQ_04", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN39_1_MQ_01_1", "THORN39_1_MQ01", "Tell him that you would persuade Marko", "Tell him that we should give up"))
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

		await dialog.Msg("THORN39_1_MQ_01_4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

