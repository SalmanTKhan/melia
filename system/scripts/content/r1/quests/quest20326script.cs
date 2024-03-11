//--- Melia Script -----------------------------------------------------------
// Farewell, My Friend (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Orville.
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

[QuestScript(20326)]
public class Quest20326Script : QuestScript
{
	protected override void Load()
	{
		SetId(20326);
		SetName("Farewell, My Friend (2)");
		SetDescription("Talk to Pilgrim Orville");

		AddPrerequisite(new LevelPrerequisite(144));
		AddPrerequisite(new CompletedPrerequisite("PILGRIMROAD55_SQ04"));
		AddPrerequisite(new ItemPrerequisite("PILGRIMROAD55_SQ09_ITEM", 1));

		AddObjective("kill0", "Kill 16 Red Infro Blood(s) or Red Infro Hoglan(s) or Burialer(s)", new KillObjective(16, 57369, 57368, 57673));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 3744));

		AddDialogHook("PILGRIMROAD55_SQ09", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIMROAD55_SQ09", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIMROAD55_SQ09_select01", "PILGRIMROAD55_SQ09", "Tell him to bury him so that he could go to the goddesses", "Comfort him before you leave"))
		{
			case 1:
				await dialog.Msg("PILGRIMROAD55_SQ09_progstartnpc01");
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

		await dialog.Msg("PILGRIMROAD55_SQ09_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

