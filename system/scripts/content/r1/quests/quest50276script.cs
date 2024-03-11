//--- Melia Script -----------------------------------------------------------
// Remembering the Victims (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Rona.
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

[QuestScript(50276)]
public class Quest50276Script : QuestScript
{
	protected override void Load()
	{
		SetId(50276);
		SetName("Remembering the Victims (1)");
		SetDescription("Talk to Rona");

		AddPrerequisite(new LevelPrerequisite(45));
		AddPrerequisite(new CompletedPrerequisite("ABBAY_64_1_SQ020"), new CompletedPrerequisite("ABBAY_64_1_SQ030"), new CompletedPrerequisite("ABBAY_64_2_SQ030"), new CompletedPrerequisite("ABBAY_64_2_SQ050"));

		AddDialogHook("BRACKEN632_TOWN_PEAPLE2", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY64_2_HIDDENQ2_OBJ2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY64_2_HQ1_start1", "ABBEY64_2_HQ1", "I'll erect the tombstones for you.", "You're better off asking someone else."))
		{
			case 1:
				dialog.UnHideNPC("ABBEY64_2_HIDDENQ2_STONE1");
				dialog.UnHideNPC("ABBEY64_2_HIDDENQ2_STONE2");
				dialog.UnHideNPC("ABBEY64_2_HIDDENQ2_STONE3");
				dialog.UnHideNPC("ABBEY64_2_HIDDENQ2_STONE4");
				dialog.UnHideNPC("ABBEY64_2_HIDDENQ2_STONE5");
				dialog.UnHideNPC("ABBEY64_2_HIDDENQ2_STONE6");
				dialog.UnHideNPC("ABBEY64_2_HIDDENQ2_OBJ2");
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

		await dialog.Msg("BalloonText/ABBEY64_2_HQ1_TABLE/5");
		await dialog.Msg("FadeOutIN/1000");
		dialog.UnHideNPC("ABBEY64_2_HIDDENQ2_OBJ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ABBEY64_2_HQ2");
	}
}

