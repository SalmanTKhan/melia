//--- Melia Script -----------------------------------------------------------
// Andale Village Priest's Favor (1)
//--- Description -----------------------------------------------------------
// Quest to Find the Andale Village Priest.
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

[QuestScript(20283)]
public class Quest20283Script : QuestScript
{
	protected override void Load()
	{
		SetId(20283);
		SetName("Andale Village Priest's Favor (1)");
		SetDescription("Find the Andale Village Priest");

		AddPrerequisite(new LevelPrerequisite(52));
		AddPrerequisite(new CompletedPrerequisite("HUEVILLAGE_58_2_MQ04"));

		AddReward(new ExpReward(118188, 118188));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 31));
		AddReward(new ItemReward("Vis", 936));

		AddDialogHook("HUEVILLAGE_58_3_MQ01_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("HUEVILLAGE_58_3_MQ01_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("HUEVILLAGE_58_3_MQ01_select01", "HUEVILLAGE_58_3_MQ01", "Ask how to help defeat the Upent", "About the Ritual", "I'll wait then"))
		{
			case 1:
				await dialog.Msg("HUEVILLAGE_58_3_MQ01_agree");
				character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Obtain Languid Herb from Narvas Curved Path");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("HUEVILLAGE_58_3_MQ01_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("HUEVILLAGE_58_3_MQ01_ITEM1", 5))
		{
			character.Inventory.RemoveItem("HUEVILLAGE_58_3_MQ01_ITEM1", 5);
			await dialog.Msg("HUEVILLAGE_58_3_MQ01_succ01");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("HUEVILLAGE_58_3_MQ02");
	}
}

