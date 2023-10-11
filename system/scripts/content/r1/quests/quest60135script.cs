//--- Melia Script -----------------------------------------------------------
// Recruiting Prisoners
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Draznie.
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

[QuestScript(60135)]
public class Quest60135Script : QuestScript
{
	protected override void Load()
	{
		SetId(60135);
		SetName("Recruiting Prisoners");
		SetDescription("Talk with Priest Draznie");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("PRISON622_MQ_05"));

		AddReward(new ExpReward(5372, 5372));
		AddReward(new ItemReward("expCard2", 2));
		AddReward(new ItemReward("Vis", 294));

		AddDialogHook("PRISON622_DRAZUNIE", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON622_DRAZUNIE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON622_SQ_04_01", "PRISON622_SQ_04", "Thank you ", "I don't think that'll happen"))
		{
			case 1:
				dialog.UnHideNPC("PRISON622_SQ_04_NPC");
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

