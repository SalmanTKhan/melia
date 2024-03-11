//--- Melia Script -----------------------------------------------------------
// Finding a Cure for the Epidemic (3)
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

[QuestScript(30277)]
public class Quest30277Script : QuestScript
{
	protected override void Load()
	{
		SetId(30277);
		SetName("Finding a Cure for the Epidemic (3)");
		SetDescription("Talk to Jugrinas");

		AddPrerequisite(new LevelPrerequisite(322));
		AddPrerequisite(new CompletedPrerequisite("WTREES_21_2_SQ_3"));

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

		switch (await dialog.Select("WTREES_21_2_SQ_4_select", "WTREES_21_2_SQ_4", "I'll collect the plant samples.", "We should get some rest first."))
		{
			case 1:
				await dialog.Msg("WTREES_21_2_SQ_4_agree");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

