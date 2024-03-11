//--- Melia Script -----------------------------------------------------------
// Creating the Languid Herb Bomb
//--- Description -----------------------------------------------------------
// Quest to Talk to Andale Village Headman.
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

[QuestScript(20285)]
public class Quest20285Script : QuestScript
{
	protected override void Load()
	{
		SetId(20285);
		SetName("Creating the Languid Herb Bomb");
		SetDescription("Talk to Andale Village Headman");

		AddPrerequisite(new LevelPrerequisite(52));
		AddPrerequisite(new CompletedPrerequisite("HUEVILLAGE_58_3_MQ02"));

		AddReward(new ExpReward(118188, 118188));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 31));
		AddReward(new ItemReward("HUEVILLAGE_58_3_MQ03_ITEM2", 1));
		AddReward(new ItemReward("Vis", 936));

		AddDialogHook("HUEVILLAGE_58_3_MQ03_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("HUEVILLAGE_58_3_MQ03_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("HUEVILLAGE_58_3_MQ03_select01", "HUEVILLAGE_58_3_MQ03", "I will go get the explosives", "That sounds dangerous"))
		{
			case 1:
				await dialog.Msg("HUEVILLAGE_58_3_MQ03_agree");
				character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Bring the explosives from the barrels located at the upper side of the village");
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

		if (character.Inventory.HasItem("HUEVILLAGE_58_3_MQ03_ITEM1", 1))
		{
			character.Inventory.RemoveItem("HUEVILLAGE_58_3_MQ03_ITEM1", 1);
			await dialog.Msg("HUEVILLAGE_58_3_MQ03_succ01");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("HUEVILLAGE_58_3_MQ04");
	}
}

