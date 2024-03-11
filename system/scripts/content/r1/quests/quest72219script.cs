//--- Melia Script -----------------------------------------------------------
// Know Your Enemy, Know Yourself (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Schaffenstar Adjutant Apollonius.
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

[QuestScript(72219)]
public class Quest72219Script : QuestScript
{
	protected override void Load()
	{
		SetId(72219);
		SetName("Know Your Enemy, Know Yourself (2)");
		SetDescription("Talk to Schaffenstar Adjutant Apollonius");

		AddPrerequisite(new LevelPrerequisite(392));
		AddPrerequisite(new CompletedPrerequisite("CASTLE93_MAIN03"));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("CASTLE93_NPC_MAIN01", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE93_NPC_MAIN01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE93_MAIN04_01", "CASTLE93_MAIN04", "Alright", "Give me some time to prepare"))
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

		await dialog.Msg("CASTLE93_MAIN04_04");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

