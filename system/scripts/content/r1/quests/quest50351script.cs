//--- Melia Script -----------------------------------------------------------
// In to the Lion's Mouth (8)
//--- Description -----------------------------------------------------------
// Quest to Look around the unidentified facility.
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

[QuestScript(50351)]
public class Quest50351Script : QuestScript
{
	protected override void Load()
	{
		SetId(50351);
		SetName("In to the Lion's Mouth (8)");
		SetDescription("Look around the unidentified facility");

		AddPrerequisite(new LevelPrerequisite(354));
		AddPrerequisite(new CompletedPrerequisite("ABBEY22_4_SQ7"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("Vis", 18054));
		AddReward(new ItemReward("expCard15", 1));

		AddDialogHook("ABBEY22_4_SUBQ7_UNKNOWN_OBJ", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY22_4_SUBQ7_UNKNOWN_OBJ", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY22_4_SUBQ8_START1", "ABBEY22_4_SQ8", "Go to the locked system to bring the parts.", "It seems too difficult for me."))
		{
			case 1:
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

		// Func/ABBEY22_4_SUBQ8_COMP_FUNC;
		await dialog.Msg("ABBEY22_4_SUBQ8_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

