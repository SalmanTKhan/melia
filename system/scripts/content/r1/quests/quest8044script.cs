//--- Melia Script -----------------------------------------------------------
// Information about Saugas (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Mercenary Eta.
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

[QuestScript(8044)]
public class Quest8044Script : QuestScript
{
	protected override void Load()
	{
		SetId(8044);
		SetName("Information about Saugas (1)");
		SetDescription("Talk to Mercenary Eta");

		AddPrerequisite(new LevelPrerequisite(64));
		AddPrerequisite(new CompletedPrerequisite("ROKAS26_SUB_Q01"));

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1216));

		AddDialogHook("ROKAS26_EHTA", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS26_EHTA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS26_SUB_Q08_01", "ROKAS26_SUB_Q08", "Then I'll help Eta", "That is impossible"))
		{
			case 1:
				await dialog.Msg("ROKAS26_SUB_Q08_04");
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
		character.Quests.Start("ROKAS26_SUB_Q09");
	}
}

