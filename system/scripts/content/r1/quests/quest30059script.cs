//--- Melia Script -----------------------------------------------------------
// Energy of Karolis Springs
//--- Description -----------------------------------------------------------
// Quest to Talk to the Owl Chief Sculpture.
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

[QuestScript(30059)]
public class Quest30059Script : QuestScript
{
	protected override void Load()
	{
		SetId(30059);
		SetName("Energy of Karolis Springs");
		SetDescription("Talk to the Owl Chief Sculpture");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("KATYN_10_MQ_10"));

		AddReward(new ExpReward(126630, 126630));
		AddReward(new ItemReward("KATYN_10_MQ_11_ITEM", 1));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 13338));

		AddDialogHook("KATYN_10_NPC_02", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_10_MQ_11_select", "KATYN_10_MQ_11", "I'm off to save the Guide Owl Sculpture", "I'll leave the end to Mardas and go"))
		{
			case 1:
				await dialog.Msg("KATYN_10_MQ_11_agree");
				dialog.UnHideNPC("KATYN_10_OBJ_04");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

