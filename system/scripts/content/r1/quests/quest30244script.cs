//--- Melia Script -----------------------------------------------------------
// Operation Outer Wall Core Retrieval (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Milda.
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

[QuestScript(30244)]
public class Quest30244Script : QuestScript
{
	protected override void Load()
	{
		SetId(30244);
		SetName("Operation Outer Wall Core Retrieval (2)");
		SetDescription("Talk to Kupole Milda");

		AddPrerequisite(new LevelPrerequisite(285));
		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_1_SQ_1"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11970));

		AddDialogHook("CASTLE_20_1_NPC_1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE_20_1_SQ_2_select", "CASTLE_20_1_SQ_2", "No problem", "I don't know what to do."))
		{
			case 1:
				await dialog.Msg("CASTLE_20_1_SQ_2_agree");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

