//--- Melia Script -----------------------------------------------------------
// Destroy the Demons' Device (1)
//--- Description -----------------------------------------------------------
// Quest to Investigate the Demons' Device.
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

[QuestScript(50190)]
public class Quest50190Script : QuestScript
{
	protected override void Load()
	{
		SetId(50190);
		SetName("Destroy the Demons' Device (1)");
		SetDescription("Investigate the Demons' Device");

		AddPrerequisite(new LevelPrerequisite(253));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 10120));

		AddDialogHook("TABLE74_SUBQ_ARTIFACT", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE74_SUBQ_ARTIFACT", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("TABLELAND_74_SQ8");
	}
}

