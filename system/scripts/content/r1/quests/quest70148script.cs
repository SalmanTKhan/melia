//--- Melia Script -----------------------------------------------------------
// Cleaning Up The Entrance
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Jeffrey.
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

[QuestScript(70148)]
public class Quest70148Script : QuestScript
{
	protected override void Load()
	{
		SetId(70148);
		SetName("Cleaning Up The Entrance");
		SetDescription("Talk to Monk Jeffrey");

		AddPrerequisite(new LevelPrerequisite(179));

		AddObjective("kill0", "Kill 12 Stonacon(s) or Green Loftlem(s) or Cire Mage(s) or Liverwort(s)", new KillObjective(12, 57682, 57664, 57650, 401481));

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 5370));

		AddDialogHook("THORN393_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("THORN393_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN39_3_SQ_03_1", "THORN39_3_SQ03", "Tell him that you would help get rid of monsters", "It will be okay"))
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

		await dialog.Msg("THORN39_3_SQ_03_4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

