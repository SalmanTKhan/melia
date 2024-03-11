//--- Melia Script -----------------------------------------------------------
// Dusk and Dawn (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Neringa.
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

[QuestScript(72260)]
public class Quest72260Script : QuestScript
{
	protected override void Load()
	{
		SetId(72260);
		SetName("Dusk and Dawn (1)");
		SetDescription("Talk to Neringa");

		AddPrerequisite(new LevelPrerequisite(446));
		AddPrerequisite(new CompletedPrerequisite("DCAPITAL53_1_MQ_06"));

		AddObjective("kill0", "Kill 15 Oak Cannoneer(s) or Orc Flagbearer(s) or Orc Captain(s)", new KillObjective(15, 59329, 59331, 59355));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("Vis", 26314));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 17));

		AddDialogHook("EP12_MAINSTREAM_NERINGA", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_MAINSTREAM_NERINGA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP12_FINALE_01_DLG01", "EP12_FINALE_01", "Alright", "End conversation"))
		{
			case 1:
				// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
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

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP12_FINALE_02");
	}
}

