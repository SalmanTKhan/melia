//--- Melia Script -----------------------------------------------------------
// Fantasy of the Watcher (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Watcher Molly.
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

[QuestScript(17130)]
public class Quest17130Script : QuestScript
{
	protected override void Load()
	{
		SetId(17130);
		SetName("Fantasy of the Watcher (1)");
		SetDescription("Talk to Watcher Molly");

		AddPrerequisite(new LevelPrerequisite(26));

		AddReward(new ExpReward(26860, 26860));
		AddReward(new ItemReward("expCard2", 2));
		AddReward(new ItemReward("Vis", 364));

		AddDialogHook("GELE571_NPC_MARLEY", "BeforeStart", BeforeStart);
		AddDialogHook("GELE571_NPC_MARLEY", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("GELE571_MQ_04_ST", "GELE571_MQ_04", "I will try", "About the Pantos", "I'm busy"))
		{
			case 1:
				dialog.UnHideNPC("GELE571_NPC_PANTO");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("GELE571_MQ_04_ST_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("GELE571_MQ_04_03");
		dialog.HideNPC("GELE571_NPC_PANTO");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

