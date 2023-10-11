//--- Melia Script -----------------------------------------------------------
// Scarecrow's Hand (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Farmer Druva.
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

[QuestScript(16530)]
public class Quest16530Script : QuestScript
{
	protected override void Load()
	{
		SetId(16530);
		SetName("Scarecrow's Hand (2)");
		SetDescription("Talk to Farmer Druva");

		AddPrerequisite(new LevelPrerequisite(166));
		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_46_2_SQ_03"));

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 4980));

		AddDialogHook("SIAULIAI_46_2_SQ_03_NPC", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_46_2_SQ_04_select", "SIAULIAI_46_2_SQ_04", "I'll have it stand", "Cancel"))
		{
			case 1:
				await dialog.Msg("SIAULIAI_46_2_SQ_04_start_prog");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

