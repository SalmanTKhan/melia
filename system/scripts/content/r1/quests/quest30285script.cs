//--- Melia Script -----------------------------------------------------------
// Laima's Prophecy Tome (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Lenja.
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

[QuestScript(30285)]
public class Quest30285Script : QuestScript
{
	protected override void Load()
	{
		SetId(30285);
		SetName("Laima's Prophecy Tome (2)");
		SetDescription("Talk to Kupole Lenja");

		AddPrerequisite(new LevelPrerequisite(325));
		AddPrerequisite(new CompletedPrerequisite("WTREES_21_1_SQ_1"));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15275));

		AddDialogHook("WTREES_21_1_NPC_1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WTREES_21_1_SQ_2_select", "WTREES_21_1_SQ_2", "Alright", "That sounds like too much for me already."))
		{
			case 1:
				await dialog.Msg("WTREES_21_1_SQ_2_agree");
				dialog.UnHideNPC("WTREES_21_1_OBJ_2");
				dialog.UnHideNPC("WTREES_21_1_OBJ_2_EFFECT");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

