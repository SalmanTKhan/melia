//--- Melia Script -----------------------------------------------------------
// Unusual Eyes
//--- Description -----------------------------------------------------------
// Quest to Talk to Accessory Merchant Jurus.
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

[QuestScript(50258)]
public class Quest50258Script : QuestScript
{
	protected override void Load()
	{
		SetId(50258);
		SetName("Unusual Eyes");
		SetDescription("Talk to Accessory Merchant Jurus");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ItemReward("misc_scrollskulp", 1));

		AddDialogHook("ORSHA_ACCESSARY_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("ORSHA_ACCESSARY_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORSHA_HQ1_start1", "ORSHA_HQ1", "I'll show you the Flower Branch.", "I'm sorry, but I don't think I can"))
		{
			case 1:
				await dialog.Msg("ORSHA_HQ1_agree1");
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

