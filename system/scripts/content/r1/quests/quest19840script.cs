//--- Melia Script -----------------------------------------------------------
// Blessing Through Money
//--- Description -----------------------------------------------------------
// Quest to Receive the Sanctum's Blessing.
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

[QuestScript(19840)]
public class Quest19840Script : QuestScript
{
	protected override void Load()
	{
		SetId(19840);
		SetName("Blessing Through Money");
		SetDescription("Receive the Sanctum's Blessing");

		AddPrerequisite(new LevelPrerequisite(129));
		AddPrerequisite(new ItemPrerequisite("Vis", 10));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3225));

		AddDialogHook("PILGRIM51_SR06", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM51_SR06", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM51_SQ_9_ST", "PILGRIM51_SQ_9", "I'll donate 10 silver.", "Don't donate"))
		{
			case 1:
				character.AddonMessage(AddonMessage.NOTICE_Dm_Exclaimation, "The Sanctum is not showing any reaction!", 3);
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

		if (character.Inventory.HasItem("PILGRIM51_ITEM_09", 1))
		{
			character.Inventory.RemoveItem("PILGRIM51_ITEM_09", 1);
			ZoneServer.Instance.World.FindNPC("PILGRIM51_SR06")?.PlayEffectLocal(character.Connection, "F_bg_fire001_2", 0.5f, "BOT");
			await Task.Delay(500);
			character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "The Sanctum has been purified");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

