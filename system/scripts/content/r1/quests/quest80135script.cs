//--- Melia Script -----------------------------------------------------------
// Blood Begets Blood
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Alena.
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

[QuestScript(80135)]
public class Quest80135Script : QuestScript
{
	protected override void Load()
	{
		SetId(80135);
		SetName("Blood Begets Blood");
		SetDescription("Talk to Kupole Alena");

		AddPrerequisite(new LevelPrerequisite(291));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_5_MQ_10"));

		AddObjective("kill0", "Kill 24 Tala Archer(s) or Green Flamme(s) or Tala Battle Boss(s)", new KillObjective(24, 58434, 58469, 58435));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 12222));

		AddDialogHook("LIMESTONE_52_2_ALLENA", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONE_52_2_ALLENA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_2_SQ_1_start", "LIMESTONE_52_2_SQ_1", "I'll defeat them.", "I'm busy now"))
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

