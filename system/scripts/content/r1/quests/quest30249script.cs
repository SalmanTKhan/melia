//--- Melia Script -----------------------------------------------------------
// Operation Outer Wall Core Retrieval (7)
//--- Description -----------------------------------------------------------
// Quest to Check the Tertiary Core Protection Device.
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

[QuestScript(30249)]
public class Quest30249Script : QuestScript
{
	protected override void Load()
	{
		SetId(30249);
		SetName("Operation Outer Wall Core Retrieval (7)");
		SetDescription("Check the Tertiary Core Protection Device");

		AddPrerequisite(new LevelPrerequisite(285));
		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_1_SQ_6"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11970));

		AddDialogHook("CASTLE_20_1_OBJ_7", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE_20_1_OBJ_7", "BeforeEnd", BeforeEnd);
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

		ZoneServer.Instance.World.FindNPC("CASTLE_20_1_OBJ_7")?.PlayEffectLocal(character.Connection, "F_burstup007_blue", 1.0f, "BOT");
		dialog.HideNPC("CASTLE_20_1_OBJ_7");
		dialog.HideNPC("CASTLE_20_1_BARRIER_2");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Disarmed the Tertiary Core Protection Device.{nl}Time to get to the restricted area.");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

