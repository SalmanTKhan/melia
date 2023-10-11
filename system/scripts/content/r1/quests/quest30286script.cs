//--- Melia Script -----------------------------------------------------------
// Demon Treaty (1)
//--- Description -----------------------------------------------------------
// Quest to Check the Treaty Seal.
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

[QuestScript(30286)]
public class Quest30286Script : QuestScript
{
	protected override void Load()
	{
		SetId(30286);
		SetName("Demon Treaty (1)");
		SetDescription("Check the Treaty Seal");

		AddPrerequisite(new LevelPrerequisite(325));
		AddPrerequisite(new CompletedPrerequisite("WTREES_21_1_SQ_2"));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));
		AddReward(new ItemReward("Vis", 15275));

		AddDialogHook("WTREES_21_1_OBJ_2", "BeforeStart", BeforeStart);
		AddDialogHook("WTREES_21_1_OBJ_2", "BeforeEnd", BeforeEnd);
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

		// Func/SCR_WTREES_21_1_SQ_3_SUCC;
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "The magic barrier was disabled and the treaty revealed itself.{nl}To obtain the demon treaty, collect the Impure Blood of Yudejan.");
		ZoneServer.Instance.World.FindNPC("WTREES_21_1_OBJ_2")?.PlayEffectLocal(character.Connection, "F_spread_in023_blue", 0.7f, "BOT");
		dialog.HideNPC("WTREES_21_1_OBJ_2_EFFECT");
		dialog.UnHideNPC("WTREES_21_1_OBJ_4");
		dialog.UnHideNPC("WTREES_21_1_OBJ_7");
		dialog.UnHideNPC("WTREES_21_1_OBJ_7_EFFECT");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

