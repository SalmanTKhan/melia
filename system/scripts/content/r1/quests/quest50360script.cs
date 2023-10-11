//--- Melia Script -----------------------------------------------------------
// Suspiciously Secretive (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Agailla Flurry Apparition.
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

[QuestScript(50360)]
public class Quest50360Script : QuestScript
{
	protected override void Load()
	{
		SetId(50360);
		SetName("Suspiciously Secretive (5)");
		SetDescription("Talk to Agailla Flurry Apparition");

		AddPrerequisite(new LevelPrerequisite(357));
		AddPrerequisite(new CompletedPrerequisite("ABBEY22_5_SQ5"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("FLURRY_CERTIFICATE2", 1));
		AddReward(new ItemReward("Vis", 18207));
		AddReward(new ItemReward("expCard15", 1));

		AddDialogHook("ABBEY225_FLURRY2", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY225_SUBQ5_NPC2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY22_5_SUBQ6_START1", "ABBEY22_5_SQ6", "Go to alter the system.", "We need more experts."))
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

		await dialog.Msg("ABBEY22_5_SUBQ6_SUCC1");
		// Func/ABBEY225_SUBQ6_COMP;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

