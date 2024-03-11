//--- Melia Script -----------------------------------------------------------
// The Disturbing Monster
//--- Description -----------------------------------------------------------
// Quest to Talk with Farm Soldier Gedson.
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

[QuestScript(70028)]
public class Quest70028Script : QuestScript
{
	protected override void Load()
	{
		SetId(70028);
		SetName("The Disturbing Monster");
		SetDescription("Talk with Farm Soldier Gedson");

		AddPrerequisite(new LevelPrerequisite(152));
		AddPrerequisite(new CompletedPrerequisite("FARM49_2_SQ01"));

		AddObjective("kill0", "Kill 20 Orange Stumpy Tree(s)", new KillObjective(20, MonsterId.Stub_Tree_Orange));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 4408));

		AddDialogHook("FARM492_SQ_02", "BeforeStart", BeforeStart);
		AddDialogHook("FARM492_SQ_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM49_2_SQ_02_1", "FARM49_2_SQ02", "I will defeat it", "I will leave the farm"))
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

		await dialog.Msg("FARM49_2_SQ_02_4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

