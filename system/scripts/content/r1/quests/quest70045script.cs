//--- Melia Script -----------------------------------------------------------
// Just the Beginning
//--- Description -----------------------------------------------------------
// Quest to Talk to Druid Martinek.
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

[QuestScript(70045)]
public class Quest70045Script : QuestScript
{
	protected override void Load()
	{
		SetId(70045);
		SetName("Just the Beginning");
		SetDescription("Talk to Druid Martinek");

		AddPrerequisite(new LevelPrerequisite(155));
		AddPrerequisite(new CompletedPrerequisite("FARM49_3_MQ05"));

		AddReward(new ExpReward(1279350, 1279350));
		AddReward(new ItemReward("expCard8", 5));
		AddReward(new ItemReward("Vis", 4495));

		AddDialogHook("FARM493_MQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("FARM493_MQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM49_3_MQ_06_1", "FARM49_3_MQ06", "I will talk to Vanessa Shaton", "Tell him that the druid should take care from here"))
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

		await dialog.Msg("FARM49_3_MQ_06_7");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

