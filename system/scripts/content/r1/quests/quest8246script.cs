//--- Melia Script -----------------------------------------------------------
// Where are the Supply Troops (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Supply Officer.
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

[QuestScript(8246)]
public class Quest8246Script : QuestScript
{
	protected override void Load()
	{
		SetId(8246);
		SetName("Where are the Supply Troops (2)");
		SetDescription("Talk to the Supply Officer");

		AddPrerequisite(new LevelPrerequisite(114));
		AddPrerequisite(new CompletedPrerequisite("KATYN14_MQ_04"));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 2736));

		AddDialogHook("KATYN14_SUPP", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN14_SUPP", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN14_MQ_05_01", "KATYN14_MQ_05", "I'll help retrieve the supplies", "I'll wait until all the supplies are retrieved"))
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

		await dialog.Msg("KATYN14_MQ_05_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("KATYN14_MQ_06");
	}
}

