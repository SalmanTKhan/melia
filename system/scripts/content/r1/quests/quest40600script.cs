//--- Melia Script -----------------------------------------------------------
// The Second Epitaph (2)
//--- Description -----------------------------------------------------------
// Quest to Ask the blacksmith in Klaipeda about adhesives.
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

[QuestScript(40600)]
public class Quest40600Script : QuestScript
{
	protected override void Load()
	{
		SetId(40600);
		SetName("The Second Epitaph (2)");
		SetDescription("Ask the blacksmith in Klaipeda about adhesives");

		AddPrerequisite(new LevelPrerequisite(172));
		AddPrerequisite(new CompletedPrerequisite("REMAINS37_2_SQ_030"));

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 5160));

		AddDialogHook("BLACKSMITH", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("REMAINS37_2_SQ_031_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("REMAINS37_2_SQ_032");
	}
}

