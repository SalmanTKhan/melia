//--- Melia Script -----------------------------------------------------------
// Recurrence Prevention (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Lanaldas.
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

[QuestScript(90017)]
public class Quest90017Script : QuestScript
{
	protected override void Load()
	{
		SetId(90017);
		SetName("Recurrence Prevention (1)");
		SetDescription("Talk to Lanaldas");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_84_MQ_03"));

		AddObjective("collect0", "Collect 8 Rajapearlite Lard(s)", new CollectItemObjective("F_3CMLAKE_84_SQ_ITEM3", 8));
		AddDrop("F_3CMLAKE_84_SQ_ITEM3", 10f, "Rajapearlite_purple");

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("Vis", 1292));

		AddDialogHook("3CMLAKE_84_PEOPLE1", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_84_PEOPLE1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("3CMLAKE_84_SQ_02_DLG_01", "F_3CMLAKE_84_SQ_02", "I'll help you so something like that doesn't happen again", "It's too dangerous; just hold on"))
		{
			case 1:
				await dialog.Msg("3CMLAKE_84_SQ_02_AG");
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


		return HookResult.Break;
	}
}

