//--- Melia Script -----------------------------------------------------------
// Cutting the Tail (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Member Irmantas.
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

[QuestScript(60045)]
public class Quest60045Script : QuestScript
{
	protected override void Load()
	{
		SetId(60045);
		SetName("Cutting the Tail (2)");
		SetDescription("Talk with Member Irmantas");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM311_SQ_02"));

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("Vis", 1640));

		AddDialogHook("PILGRIM311_IRMANTAS_02", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM311_IRMANTAS_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM311_SQ_03_01", "PILGRIM311_SQ_03", "Yeah, I'll collect them", "I'm not sure"))
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


		return HookResult.Break;
	}
}

