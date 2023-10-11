//--- Melia Script -----------------------------------------------------------
// Recruiting Mercenaries (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Mercenary Toby.
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

[QuestScript(7074)]
public class Quest7074Script : QuestScript
{
	protected override void Load()
	{
		SetId(7074);
		SetName("Recruiting Mercenaries (2)");
		SetDescription("Talk to Mercenary Toby");

		AddPrerequisite(new LevelPrerequisite(61));
		AddPrerequisite(new CompletedPrerequisite("ROKAS25_EX1"));

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1159));

		AddDialogHook("ROKAS25_SUB1", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS25_SUB1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS25_EX2_select1", "ROKAS25_EX2", "I'll pick up and bring the tools for excavation for evidence", "I won't do such job"))
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

		await dialog.Msg("ROKAS25_EX2_succ1");
		dialog.HideNPC("ROKAS25_EX2_STRUCTURE");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

