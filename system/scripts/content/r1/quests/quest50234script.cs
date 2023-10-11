//--- Melia Script -----------------------------------------------------------
// Weeding(3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Kidas.
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

[QuestScript(50234)]
public class Quest50234Script : QuestScript
{
	protected override void Load()
	{
		SetId(50234);
		SetName("Weeding(3)");
		SetDescription("Talk to Priest Kidas");

		AddPrerequisite(new LevelPrerequisite(316));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_4_SQ10"));

		AddDialogHook("BRACKEN434_SUBQ9_NPC2", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN434_SUBQ9_NPC2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN43_4_SQ10_1_START1", "BRACKEN43_4_SQ10_1", "Wait and see", "Just go"))
		{
			case 1:
				// Func/BRACKEN434_SUBQ10_1_AGREE_FUNC;
				await dialog.Msg("BalloonText/BRACKEN434_SUBQ10_1_MSG/3");
				await dialog.Msg("FadeOutIN/2000");
				dialog.HideNPC("BRACKEN434_OBJ");
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

		await dialog.Msg("BRACKEN43_4_SQ10_1_SUCC1");
		dialog.HideNPC("BRACKEN434_SUBQ9_NPC2");
		dialog.HideNPC("BRACKEN434_SUBQ10_NPC3");
		await dialog.Msg("FadeOutIN/1000");
		dialog.UnHideNPC("BRACKEN434_SUBQ10_NPC1");
		dialog.UnHideNPC("BRACKEN434_SUBQ9_NPC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

