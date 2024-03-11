//--- Melia Script -----------------------------------------------------------
// In to the Lion's Mouth (9)
//--- Description -----------------------------------------------------------
// Quest to Talk to Agailla Flurry Apparition.
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

[QuestScript(50352)]
public class Quest50352Script : QuestScript
{
	protected override void Load()
	{
		SetId(50352);
		SetName("In to the Lion's Mouth (9)");
		SetDescription("Talk to Agailla Flurry Apparition");

		AddPrerequisite(new LevelPrerequisite(354));
		AddPrerequisite(new CompletedPrerequisite("ABBEY22_4_SQ8"));

		AddDialogHook("ABBEY22_4_SUBQ8_FLURRY", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY22_4_SUBQ7_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY22_4_SUBQ9_START1", "ABBEY22_4_SQ9", "Follow her words.", "Decline"))
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

		await dialog.Msg("ABBEY22_4_SUBQ9_SUCC1");
		// Func/SCR_ABBEY224_SUQ9_COMP;
		await dialog.Msg("ABBEY22_4_SUBQ9_SUCC2");
		dialog.HideNPC("ABBEY22_4_SUBQ7_NPC1");
		dialog.UnHideNPC("ABBEY22_4_SUBQ10_NPC1");
		await dialog.Msg("FadeOutIN/1000");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

