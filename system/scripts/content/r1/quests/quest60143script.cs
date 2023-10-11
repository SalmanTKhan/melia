//--- Melia Script -----------------------------------------------------------
// Precious and Valuable
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

[QuestScript(60143)]
public class Quest60143Script : QuestScript
{
	protected override void Load()
	{
		SetId(60143);
		SetName("Precious and Valuable");
		SetDescription("Talk with Priest Gelija");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(5372, 5372));
		AddReward(new ItemReward("expCard2", 2));
		AddReward(new ItemReward("Vis", 350));

		AddDialogHook("PRISON623_GELIYA", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON623_GELIYA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON623_SQ_02_01", "PRISON623_SQ_02", "I will go look for it", "I think it's best to get out of the prison"))
		{
			case 1:
				dialog.UnHideNPC("PRISON623_SQ_02_NPC");
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

