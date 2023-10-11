//--- Melia Script -----------------------------------------------------------
// Days to Forget
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Gelija.
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

[QuestScript(60154)]
public class Quest60154Script : QuestScript
{
	protected override void Load()
	{
		SetId(60154);
		SetName("Days to Forget");
		SetDescription("Talk with Priest Gelija");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 15 Varv(s)", new KillObjective(15, MonsterId.Sec_Varv));

		AddReward(new ExpReward(2686, 2686));
		AddReward(new ItemReward("expCard2", 1));
		AddReward(new ItemReward("Vis", 350));

		AddDialogHook("PRISON623_GELIYA", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON623_GELIYA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON623_RP_1_1", "PRISON623_RP_1", "I'll help you", "I don't want to get my hands dirty"))
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

