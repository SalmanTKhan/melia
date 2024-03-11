//--- Melia Script -----------------------------------------------------------
// Marks of a legend(2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Mechen.
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

[QuestScript(50212)]
public class Quest50212Script : QuestScript
{
	protected override void Load()
	{
		SetId(50212);
		SetName("Marks of a legend(2)");
		SetDescription("Talk to Mechen");

		AddPrerequisite(new LevelPrerequisite(313));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_3_SQ1"));

		AddDialogHook("BRACKEN433_SUBQ2_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN433_SUBQ2_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN43_3_SQ2_START1", "BRACKEN43_3_SQ2", "Say that you will assist in finding the Flechette", "Wish him the best in finding what he is looking for"))
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

		await dialog.Msg("BRACKEN43_3_SQ2_SUCC1");
		await dialog.Msg("BalloonText/BRACKEN433_SUBQ2_MSG1/5");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

