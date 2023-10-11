//--- Melia Script -----------------------------------------------------------
// Despite Urgent Matters
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Siute.
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

[QuestScript(80147)]
public class Quest80147Script : QuestScript
{
	protected override void Load()
	{
		SetId(80147);
		SetName("Despite Urgent Matters");
		SetDescription("Talk to Kupole Siute");

		AddPrerequisite(new LevelPrerequisite(294));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_5_MQ_10"));

		AddObjective("kill0", "Kill 12 Green Flamme(s) or Green Flamme Mage(s) or Green Bavon(s) or Green Rubblem(s)", new KillObjective(12, 58469, 58470, 58467, 58468));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 12348));

		AddDialogHook("LIMESTONECAVE_52_3_SIUTE_2", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONECAVE_52_3_SIUTE_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_3_SQ_1_start", "LIMESTONE_52_3_SQ_1", "Alright", "I'm busy now"))
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

