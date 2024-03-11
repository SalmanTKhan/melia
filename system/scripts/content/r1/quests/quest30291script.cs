//--- Melia Script -----------------------------------------------------------
// Goddess Treaty (1)
//--- Description -----------------------------------------------------------
// Quest to Use the Goddess' Stone of Faith to Read the Tombstone and Release the Seal.
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

[QuestScript(30291)]
public class Quest30291Script : QuestScript
{
	protected override void Load()
	{
		SetId(30291);
		SetName("Goddess Treaty (1)");
		SetDescription("Use the Goddess' Stone of Faith to Read the Tombstone and Release the Seal");

		AddPrerequisite(new LevelPrerequisite(325));
		AddPrerequisite(new CompletedPrerequisite("WTREES_21_1_SQ_7"));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("WTREES_21_1_SQ_8_ITEM", 1));
		AddReward(new ItemReward("expCard14", 2));
		AddReward(new ItemReward("Vis", 15275));

		AddDialogHook("WTREES_21_1_OBJ_7", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "The goddess treaty is now in your hands.{nl}Return to the site of the treaty seal.");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

