//--- Melia Script -----------------------------------------------------------
// Suspiciously Secretive (7)
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

[QuestScript(50362)]
public class Quest50362Script : QuestScript
{
	protected override void Load()
	{
		SetId(50362);
		SetName("Suspiciously Secretive (7)");
		SetDescription("Talk to Agailla Flurry Apparition");

		AddPrerequisite(new LevelPrerequisite(357));
		AddPrerequisite(new CompletedPrerequisite("ABBEY22_5_SQ7"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("Vis", 18207));
		AddReward(new ItemReward("expCard15", 1));

		AddDialogHook("ABBEY225_FLURRY3", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY225_FLURRY3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY22_5_SUBQ8_START1", "ABBEY22_5_SQ8", "How would you like to do this?", "Leave the area."))
		{
			case 1:
				await dialog.Msg("ABBEY22_5_SUBQ8_AGR1");
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

		await dialog.Msg("ABBEY22_5_SUBQ8_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

