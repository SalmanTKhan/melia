//--- Melia Script -----------------------------------------------------------
// Finding a Cure for the Epidemic (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Jugrinas.
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

[QuestScript(30276)]
public class Quest30276Script : QuestScript
{
	protected override void Load()
	{
		SetId(30276);
		SetName("Finding a Cure for the Epidemic (2)");
		SetDescription("Talk to Jugrinas");

		AddPrerequisite(new LevelPrerequisite(322));
		AddPrerequisite(new CompletedPrerequisite("WTREES_21_2_SQ_2"));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15134));

		AddDialogHook("WTREES_21_2_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("WTREES_21_2_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WTREES_21_2_SQ_3_select", "WTREES_21_2_SQ_3", "I will come back after setting it", "Let's do something else instead."))
		{
			case 1:
				await dialog.Msg("WTREES_21_2_SQ_3_agree");
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

		await dialog.Msg("WTREES_21_2_SQ_3_succ");
		dialog.UnHideNPC("WTREES_21_2_OBJ_2_1");
		dialog.UnHideNPC("WTREES_21_2_OBJ_2_2");
		dialog.UnHideNPC("WTREES_21_2_OBJ_2_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

