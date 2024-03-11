//--- Melia Script -----------------------------------------------------------
// Finding a Cure for the Epidemic (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Jugrinas.
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

[QuestScript(30279)]
public class Quest30279Script : QuestScript
{
	protected override void Load()
	{
		SetId(30279);
		SetName("Finding a Cure for the Epidemic (5)");
		SetDescription("Talk to Jugrinas");

		AddPrerequisite(new LevelPrerequisite(322));
		AddPrerequisite(new CompletedPrerequisite("WTREES_21_2_SQ_5"));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));
		AddReward(new ItemReward("Vis", 15134));

		AddDialogHook("WTREES_21_2_NPC_1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WTREES_21_2_SQ_6_select", "WTREES_21_2_SQ_6", "I'll collect the monster samples.", "Are you completely out of your mind?"))
		{
			case 1:
				await dialog.Msg("WTREES_21_2_SQ_6_agree");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

