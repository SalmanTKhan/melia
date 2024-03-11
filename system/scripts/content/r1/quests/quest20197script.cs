//--- Melia Script -----------------------------------------------------------
// Self Sufficiency (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Epigraphist Raymond.
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

[QuestScript(20197)]
public class Quest20197Script : QuestScript
{
	protected override void Load()
	{
		SetId(20197);
		SetName("Self Sufficiency (1)");
		SetDescription("Talk to Epigraphist Raymond");

		AddPrerequisite(new LevelPrerequisite(96));

		AddObjective("collect0", "Collect 10 Stumpy Tree Branch(s)", new CollectItemObjective("REMAIN37_MQ01_ITEM", 10));
		AddDrop("REMAIN37_MQ01_ITEM", 10f, "stub_tree");

		AddReward(new ExpReward(122855, 122855));
		AddReward(new ItemReward("expCard6", 1));
		AddReward(new ItemReward("Vis", 1920));

		AddDialogHook("REMAIN37_RAYMOND", "BeforeStart", BeforeStart);
		AddDialogHook("REMAIN37_RAYMOND", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAIN37_MQ01_select01", "REMAIN37_MQ01", "I will try", "About Ruklys", "I'm not interested"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("REMAIN37_MQ01_AG");
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

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("REMAIN37_MQ02");
	}
}

