//--- Melia Script -----------------------------------------------------------
// Light Attack (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Follower Tiberius.
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

[QuestScript(8523)]
public class Quest8523Script : QuestScript
{
	protected override void Load()
	{
		SetId(8523);
		SetName("Light Attack (1)");
		SetDescription("Talk to Follower Tiberius");

		AddPrerequisite(new LevelPrerequisite(40));

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 600));

		AddDialogHook("CHAPEL_TABERIJUS", "BeforeStart", BeforeStart);
		AddDialogHook("CHAPEL_TABERIJUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHAPLE575_MQ_05_01", "CHAPLE575_MQ_05", "Alright, I'll help you", "It doesn't seem like a good idea"))
		{
			case 1:
				await dialog.Msg("CHAPLE575_MQ_05_AG");
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

		await dialog.Msg("CHAPLE575_MQ_05_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

