//--- Melia Script -----------------------------------------------------------
// Operation Outer Wall Core Retrieval (6)
//--- Description -----------------------------------------------------------
// Quest to Check the Secondary Core Protection Device.
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

[QuestScript(30248)]
public class Quest30248Script : QuestScript
{
	protected override void Load()
	{
		SetId(30248);
		SetName("Operation Outer Wall Core Retrieval (6)");
		SetDescription("Check the Secondary Core Protection Device");

		AddPrerequisite(new LevelPrerequisite(285));
		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_1_SQ_5"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11970));

		AddDialogHook("CASTLE_20_1_OBJ_6", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE_20_1_OBJ_6", "BeforeEnd", BeforeEnd);
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

		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "The Secondary Core Protection Device has been disarmed.{nl}Now, on to the Tertiary Core Protection Device.");
		ZoneServer.Instance.World.FindNPC("CASTLE_20_1_OBJ_6")?.PlayEffectLocal(character.Connection, "F_light082_line_red", 2.0f, "BOT");
		dialog.HideNPC("CASTLE_20_1_OBJ_6_1");
		dialog.HideNPC("CASTLE_20_1_OBJ_6_2");
		dialog.HideNPC("CASTLE_20_1_OBJ_6_3");
		dialog.HideNPC("CASTLE_20_1_OBJ_6_4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

