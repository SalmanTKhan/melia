//--- Melia Script -----------------------------------------------------------
// The Fearless Ones
//--- Description -----------------------------------------------------------
// Quest to Talk to Watcher Gilbert.
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

[QuestScript(17100)]
public class Quest17100Script : QuestScript
{
	protected override void Load()
	{
		SetId(17100);
		SetName("The Fearless Ones");
		SetDescription("Talk to Watcher Gilbert");

		AddPrerequisite(new LevelPrerequisite(26));

		AddObjective("kill0", "Kill 5 Zignuts(s)", new KillObjective(5, MonsterId.Zignuts));
		AddObjective("kill1", "Kill 4 Grummer(s)", new KillObjective(4, MonsterId.Grummer));

		AddReward(new ExpReward(26860, 26860));
		AddReward(new ItemReward("expCard2", 2));
		AddReward(new ItemReward("Drug_SP1_Q", 30));
		AddReward(new ItemReward("Vis", 364));

		AddDialogHook("GELE571_NPC_GILBERT", "BeforeStart", BeforeStart);
		AddDialogHook("GELE571_NPC_GILBERT", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("GELE571_MQ_02_ST", "GELE571_MQ_01", "I'll teach them a lesson", "About the Watchers", "Leave if for him to do it himself"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("GELE571_MQ_02_ST_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("GELE571_MQ_01_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

