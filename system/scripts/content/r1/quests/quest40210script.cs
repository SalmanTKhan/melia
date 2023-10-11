//--- Melia Script -----------------------------------------------------------
// Cleaning the Strange Aura (1)
//--- Description -----------------------------------------------------------
// Quest to Look for the magic circle that needs to be enhanced.
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

[QuestScript(40210)]
public class Quest40210Script : QuestScript
{
	protected override void Load()
	{
		SetId(40210);
		SetName("Cleaning the Strange Aura (1)");
		SetDescription("Look for the magic circle that needs to be enhanced");

		AddPrerequisite(new LevelPrerequisite(86));
		AddPrerequisite(new CompletedPrerequisite("FARM47_3_SQ_030"));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 1720));

		AddDialogHook("FARM47_MAGIC01", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_MAGIC01", "BeforeEnd", BeforeEnd);
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

		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "The magic circle has been enhanced when you removed the 4 crystals!");
		dialog.HideNPC("FARM47_PROTECT_GEM_1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

