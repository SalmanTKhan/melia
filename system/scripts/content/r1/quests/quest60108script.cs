//--- Melia Script -----------------------------------------------------------
// Preliminary Investigation (2)
//--- Description -----------------------------------------------------------
// Quest to Check out at the Deer Hooves Lot.
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

[QuestScript(60108)]
public class Quest60108Script : QuestScript
{
	protected override void Load()
	{
		SetId(60108);
		SetName("Preliminary Investigation (2)");
		SetDescription("Check out at the Deer Hooves Lot");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SIAU11RE_SQ_04_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("SIAU11RE_SQ_03"));

		AddObjective("kill0", "Kill 1 Gray Golem", new KillObjective(1, MonsterId.Boss_Golem_Gray_Q3));

		AddReward(new ExpReward(5372, 5372));
		AddReward(new ItemReward("expCard2", 2));
		AddReward(new ItemReward("Vis", 169));
		AddReward(new ItemReward("TreasureboxKey2", 1));

		AddDialogHook("SIAULIAI11RE_NOTORESU", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

