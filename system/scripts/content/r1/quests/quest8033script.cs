//--- Melia Script -----------------------------------------------------------
// Unfinished Commission (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Archaeologist Laudi.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Zone;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;

[QuestScript(8033)]
public class Quest8033Script : QuestScript
{
	protected override void Load()
	{
		SetId(8033);
		SetName("Unfinished Commission (2)");
		SetDescription("Talk to Archaeologist Laudi");

		AddPrerequisite(new LevelPrerequisite(64));
		AddPrerequisite(new CompletedPrerequisite("ROKAS26_QUEST01"));

		AddObjective("kill0", "Kill 12 Wendigo(s) or Dumaro(s) or Wendigo Archer(s) or Wendigo Magician(s)", new KillObjective(12, 41446, 57038, 57621, 57619));

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1216));

		AddDialogHook("ROKAS26_REXIPHER1", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS26_REXIPHER1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS26_QUEST02_1", "ROKAS26_QUEST02", "I will help in defeating the monsters", "I don't have time for that"))
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

		dialog.UnHideNPC("ROKAS26_QUEST03_STONE");
		await dialog.Msg("ROKAS26_QUEST02_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

