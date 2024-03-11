//--- Melia Script -----------------------------------------------------------
// Training Camp Owl (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Lonely Owl Sculpture.
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

[QuestScript(90044)]
public class Quest90044Script : QuestScript
{
	protected override void Load()
	{
		SetId(90044);
		SetName("Training Camp Owl (3)");
		SetDescription("Talk to the Lonely Owl Sculpture");

		AddPrerequisite(new LevelPrerequisite(249));
		AddPrerequisite(new CompletedPrerequisite("KATYN_45_2_SQ_2"));

		AddDialogHook("KATYN_45_2_OWL2", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_2_AJEL1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_45_2_SQ_3_ST", "KATYN_45_2_SQ_3"))
		{
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("KATYN_45_2_SQ_3_SU");
		await dialog.Msg("BalloonText/KATYN_45_2_SQ_3_SU2/3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

