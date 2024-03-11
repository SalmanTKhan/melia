//--- Melia Script -----------------------------------------------------------
// Checking the Portal
//--- Description -----------------------------------------------------------
// Quest to Talk to the Injured Villager.
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

[QuestScript(18130)]
public class Quest18130Script : QuestScript
{
	protected override void Load()
	{
		SetId(18130);
		SetName("Checking the Portal");
		SetDescription("Talk to the Injured Villager");

		AddPrerequisite(new LevelPrerequisite(36));
		AddPrerequisite(new CompletedPrerequisite("HUEVILLAGE_58_1_MQ03"));

		AddReward(new ExpReward(67536, 67536));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 31));
		AddReward(new ItemReward("Vis", 504));

		AddDialogHook("HUEVILLAGE_58_1_MQ03_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("HUEVILLAGE_58_1_MQ03_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("HUEVILLAGE_58_1_MQ04_select", "HUEVILLAGE_58_1_MQ04", "I'll check the sanctum for you", "About the portal", "Worry about the wound"))
		{
			case 1:
				await dialog.Msg("HUEVILLAGE_58_1_MQ04_agree");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("HUEVILLAGE_58_1_MQ04_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("HUEVILLAGE_58_1_MQ04_succ");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Find the village elder at Vieta Gorge! ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

