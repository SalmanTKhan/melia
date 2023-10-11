//--- Melia Script -----------------------------------------------------------
// Camaraderie
//--- Description -----------------------------------------------------------
// Quest to Talk to Guard Lyle.
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

[QuestScript(8823)]
public class Quest8823Script : QuestScript
{
	protected override void Load()
	{
		SetId(8823);
		SetName("Camaraderie");
		SetDescription("Talk to Guard Lyle");

		AddPrerequisite(new LevelPrerequisite(190));

		AddObjective("kill0", "Kill 6 Denden(s) or Moyabu(s) or Goblin Warrior(s)", new KillObjective(6, 47478, 47470, 57635));

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("Vis", 5890));

		AddDialogHook("FLASH61_LAIL", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH61_LAIL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH61_SQ_02_01", "FLASH61_SQ_02", "Sure, I'll help", "About the support", "That's too much"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FLASH61_SQ_02_01_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FLASH61_SQ_02_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

