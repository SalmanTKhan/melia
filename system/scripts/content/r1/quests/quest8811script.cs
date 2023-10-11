//--- Melia Script -----------------------------------------------------------
// White Lie (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Grave Robber Benjaminas.
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

[QuestScript(8811)]
public class Quest8811Script : QuestScript
{
	protected override void Load()
	{
		SetId(8811);
		SetName("White Lie (2)");
		SetDescription("Talk to Grave Robber Benjaminas");

		AddPrerequisite(new LevelPrerequisite(184));
		AddPrerequisite(new CompletedPrerequisite("FLASH59_SQ_11"));

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 5704));

		AddDialogHook("FLASH59_BENJAMINAS", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH59_BENJAMINAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH59_SQ_12_01", "FLASH59_SQ_12", "I'll go there", "It's not yet time"))
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

		await dialog.Msg("FLASH59_SQ_12_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

