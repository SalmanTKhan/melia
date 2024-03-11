//--- Melia Script -----------------------------------------------------------
// Unknown Poison (1)
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

[QuestScript(70122)]
public class Quest70122Script : QuestScript
{
	protected override void Load()
	{
		SetId(70122);
		SetName("Unknown Poison (1)");
		SetDescription("Talk to Hunter Natasha");

		AddPrerequisite(new LevelPrerequisite(176));
		AddPrerequisite(new CompletedPrerequisite("THORN39_1_MQ02"));

		AddDialogHook("THORN391_MQ_05", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN39_1_MQ_03_1", "THORN39_1_MQ03", "Tell him that you would come back fast", "Tell him that it will be better to move to a city"))
		{
			case 1:
				await dialog.Msg("THORN39_1_MQ_03_2");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("THORN39_1_MQ04");
	}
}

