//--- Melia Script -----------------------------------------------------------
// Old Seeds (1)
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

[QuestScript(70024)]
public class Quest70024Script : QuestScript
{
	protected override void Load()
	{
		SetId(70024);
		SetName("Old Seeds (1)");
		SetDescription("Talk to Druid Martinek");

		AddPrerequisite(new LevelPrerequisite(152));
		AddPrerequisite(new CompletedPrerequisite("FARM49_2_MQ04"));

		AddReward(new ExpReward(852900, 852900));
		AddReward(new ItemReward("expCard8", 4));
		AddReward(new ItemReward("Vis", 4408));

		AddDialogHook("FARM492_MQ_04", "BeforeStart", BeforeStart);
		AddDialogHook("FARM492_MQ_04", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM49_2_MQ_05_1", "FARM49_2_MQ05", "I'll help", "About the seeds", "Tell him that the tasks can't be completed by you"))
		{
			case 1:
				await dialog.Msg("FARM49_2_MQ_05_2");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FARM49_2_MQ_05_3");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FARM49_2_MQ_05_5");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

