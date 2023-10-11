//--- Melia Script -----------------------------------------------------------
// Fading Spirit
//--- Description -----------------------------------------------------------
// Quest to Talk to the Frail Owl Sculpture.
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

[QuestScript(60165)]
public class Quest60165Script : QuestScript
{
	protected override void Load()
	{
		SetId(60165);
		SetName("Fading Spirit");
		SetDescription("Talk to the Frail Owl Sculpture");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(8442, 8442));
		AddReward(new ItemReward("expCard3", 1));
		AddReward(new ItemReward("Vis", 1159));

		AddDialogHook("KATYN12_RP_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN12_RP_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN12_RP_1_1", "KATYN12_RP_1", "I'll help you", "I'm busy"))
		{
			case 1:
				// Func/KATYN12_RP_1_SCP_RUN_1;
				dialog.UnHideNPC("KATYN12_RP_1_OBJ");
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


		return HookResult.Break;
	}
}

