//--- Melia Script -----------------------------------------------------------
// Crystal Stone at the Crossroad (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Beholder.
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

[QuestScript(72104)]
public class Quest72104Script : QuestScript
{
	protected override void Load()
	{
		SetId(72104);
		SetName("Crystal Stone at the Crossroad (2)");
		SetDescription("Talk to the Beholder");

		AddPrerequisite(new LevelPrerequisite(333));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE261_SQ04"));

		AddReward(new ItemReward("3CMLAKE261_SQ06_ITEM", 1));

		AddDialogHook("3CMLAKE_BLACKMAN02", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("3CMLAKE261_SQ05_DLG01", "F_3CMLAKE261_SQ05", "Alright", "I won't do it."))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("F_3CMLAKE261_SQ06");
	}
}

