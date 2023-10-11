//--- Melia Script -----------------------------------------------------------
// The Missing Bishop (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Item Merchant.
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

[QuestScript(60087)]
public class Quest60087Script : QuestScript
{
	protected override void Load()
	{
		SetId(60087);
		SetName("The Missing Bishop (3)");
		SetDescription("Talk to the Item Merchant");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ORSHA_MQ1_02"));

		AddReward(new ItemReward("BRC01_122", 1));

		AddDialogHook("ORSHA_TOOL_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("ORSHA_ACCESSARY_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORSHA_MQ1_03_01", "ORSHA_MQ1_03", "Thank you for letting me know", "I'm afraid I can't help you with that"))
		{
			case 1:
				character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Find the Accessory Merchant");
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

