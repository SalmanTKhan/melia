//--- Melia Script -----------------------------------------------------------
// Flowers to the Enraged Soul
//--- Description -----------------------------------------------------------
// Quest to Chliz Uphill Altar.
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

[QuestScript(19660)]
public class Quest19660Script : QuestScript
{
	protected override void Load()
	{
		SetId(19660);
		SetName("Flowers to the Enraged Soul");
		SetDescription("Chliz Uphill Altar");

		AddPrerequisite(new LevelPrerequisite(127));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("PILGRIM50_ITEM_03", 1));
		AddReward(new ItemReward("Vis", 3175));

		AddDialogHook("PILGRIM50_ANGRY01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM50_ANGRY01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You've cleaned the altar!");
		dialog.HideNPC("PILGRIM50_BUNT_1");
		dialog.HideNPC("PILGRIM50_BUNT_2");
		dialog.HideNPC("PILGRIM50_BUNT_3");
		dialog.HideNPC("PILGRIM50_BUNT_4");
		dialog.HideNPC("PILGRIM50_BUNT_5");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

