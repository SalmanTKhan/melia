//--- Melia Script -----------------------------------------------------------
// Investigate Inner Wall District 8 (6)
//--- Description -----------------------------------------------------------
// Quest to Check the magic circle.
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

[QuestScript(30225)]
public class Quest30225Script : QuestScript
{
	protected override void Load()
	{
		SetId(30225);
		SetName("Investigate Inner Wall District 8 (6)");
		SetDescription("Check the magic circle");

		AddPrerequisite(new LevelPrerequisite(279));
		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_3_SQ_6"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11439));

		AddDialogHook("CASTLE_20_3_OBJ_7", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE_20_3_OBJ_7", "BeforeEnd", BeforeEnd);
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

		ZoneServer.Instance.World.FindNPC("CASTLE_20_3_OBJ_7")?.PlayEffectLocal(character.Connection, "F_light089_green", 0.8f, "BOT");
		await Task.Delay(3000);
		// Func/SCR_CASTLE_20_3_SQ_CLUE_RUN/3;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

