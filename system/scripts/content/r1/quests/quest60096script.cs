//--- Melia Script -----------------------------------------------------------
// Turning Away
//--- Description -----------------------------------------------------------
// Quest to Talk with Chaser Germeja.
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

[QuestScript(60096)]
public class Quest60096Script : QuestScript
{
	protected override void Load()
	{
		SetId(60096);
		SetName("Turning Away");
		SetDescription("Talk with Chaser Germeja");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(1500, 1500));
		AddReward(new ItemReward("expCard1", 3));
		AddReward(new ItemReward("Vis", 104));

		AddDialogHook("SIAULIAI15RE_GERMEYA", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI15RE_GERMEYA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAU15RE_SQ_03_01", "SIAU15RE_SQ_03", "Thank you ", "Thank you but I have to decline"))
		{
			case 1:
				dialog.ShowHelp("SIAU15RE_SQ_03");
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

