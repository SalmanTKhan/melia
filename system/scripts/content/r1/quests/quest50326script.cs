//--- Melia Script -----------------------------------------------------------
// A Dog Wandering Tekel Shelter
//--- Description -----------------------------------------------------------
// Quest to Talk to the dog with no owner.
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

[QuestScript(50326)]
public class Quest50326Script : QuestScript
{
	protected override void Load()
	{
		SetId(50326);
		SetName("A Dog Wandering Tekel Shelter");
		SetDescription("Talk to the dog with no owner");

		AddPrerequisite(new LevelPrerequisite(348));

		AddDialogHook("WTREES22_2_SUBQ1_PRE_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("WTREES22_2_SUBQ1_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WTREES22_2_SUBQ1_START1", "WTREES22_2_SQ1", "Follow.", "Don't Follow."))
		{
			case 1:
				// Func/WTREES22_2_SUBQ1_AG_FUNC;
				await dialog.Msg("BalloonText/WTREES22_2_SUBQ1_UI_MSG1/3");
				await dialog.Msg("FadeOutIN/1000");
				dialog.HideNPC("WTREES22_2_SUBQ1_PRE_NPC1");
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

		await dialog.Msg("WTREES22_2_SQ1_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

