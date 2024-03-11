//--- Melia Script -----------------------------------------------------------
// Bishop's Dream of the Goddess (1)
//--- Description -----------------------------------------------------------
// Quest to Move to Klaipeda and Talk to Knight Commander Uska.
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

[QuestScript(20236)]
public class Quest20236Script : QuestScript
{
	protected override void Load()
	{
		SetId(20236);
		SetName("Bishop's Dream of the Goddess (1)");
		SetDescription("Move to Klaipeda and Talk to Knight Commander Uska");

		AddPrerequisite(new LevelPrerequisite(7));
		AddPrerequisite(new CompletedPrerequisite("SIAUL_WEST_LAIMONAS1"));

		AddReward(new ItemReward("Scroll_Warp_quest", 10));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 6));

		AddDialogHook("KLAPEDA_USKA", "BeforeStart", BeforeStart);
		AddDialogHook("EMILIA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EAST_PREPARE_select01", "EAST_PREPARE", "I'll go to the Eastern Woods", "I don't want to go"))
		{
			case 1:
				await dialog.Msg("EAST_PREPARE_02");
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

		//SCR_BASIC_CITY_WARP_OPEN/WARP_C_ORSHA
		await dialog.Msg("EAST_PREPARE_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EAST_PREPARE_1");
	}
}

