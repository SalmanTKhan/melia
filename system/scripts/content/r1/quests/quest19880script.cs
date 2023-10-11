//--- Melia Script -----------------------------------------------------------
// Avoiding Infatuation (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Theophilis.
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

[QuestScript(19880)]
public class Quest19880Script : QuestScript
{
	protected override void Load()
	{
		SetId(19880);
		SetName("Avoiding Infatuation (2)");
		SetDescription("Talk to Pilgrim Theophilis");

		AddPrerequisite(new LevelPrerequisite(133));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM52_SQ_011"));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3325));

		AddDialogHook("PILGRIM52_NPC01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM52_NPC01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM52_SQ_020_ST", "PILGRIM52_SQ_020", "I will get the materials", "About the cause of the wound", "Wait for the next chance"))
		{
			case 1:
				await dialog.Msg("PILGRIM52_SQ_020_AC");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("PILGRIM52_SQ_020_ADD");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("PILGRIM52_SQ_020_COMP");
		await Task.Delay(3000);
		// Func/SCR_PILGRIM52_PC_DRINK_ANI;
		character.PlayEffectLocal("F_light003_violet");
		await dialog.Msg("PILGRIM52_SQ_020_COMP_2");
		// Func/SCR_PILGRIM52_SQ_020_ASIDE;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

