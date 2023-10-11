//--- Melia Script -----------------------------------------------------------
// Great Escape Portal (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Chronomancer Sabina.
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

[QuestScript(8831)]
public class Quest8831Script : QuestScript
{
	protected override void Load()
	{
		SetId(8831);
		SetName("Great Escape Portal (2)");
		SetDescription("Talk to Chronomancer Sabina");

		AddPrerequisite(new LevelPrerequisite(190));
		AddPrerequisite(new CompletedPrerequisite("FLASH61_SQ_09"));

		AddObjective("kill0", "Kill 8 Goblin Warrior(s) or Moyabu(s) or Denden(s)", new KillObjective(8, 57635, 47470, 47478));

		AddReward(new ExpReward(2379430, 2379430));
		AddReward(new ItemReward("expCard10", 2));
		AddReward(new ItemReward("Vis", 5890));

		AddDialogHook("FLASH61_SABINA", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH61_SABINA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH61_SQ_10_01", "FLASH61_SQ_10", "Leave it to me", "Tell him that you would quit from here"))
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

		await dialog.Msg("FLASH61_SQ_10_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

