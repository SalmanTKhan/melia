//--- Melia Script -----------------------------------------------------------
// Unsafe Safety Zone
//--- Description -----------------------------------------------------------
// Quest to Talk with Settler Dallanas.
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

[QuestScript(60083)]
public class Quest60083Script : QuestScript
{
	protected override void Load()
	{
		SetId(60083);
		SetName("Unsafe Safety Zone");
		SetDescription("Talk with Settler Dallanas");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 15 Kepa(s) or Leaf Bug(s) or Chupaluka(s) or Chinency(s) or Weaver(s) or Yellow Old Kepa(s)", new KillObjective(15, 58005, 58006, 58090, 58008, 58093, 400482));

		AddReward(new ExpReward(1000, 1000));
		AddReward(new ItemReward("expCard1", 2));
		AddReward(new ItemReward("Vis", 13));

		AddDialogHook("SIAULIAI16_DALLANAS", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI16_DALLANAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAU16_SQ_07_01", "SIAU16_SQ_07", "Alright, I'll help you", "I'm not talented enough for that"))
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

