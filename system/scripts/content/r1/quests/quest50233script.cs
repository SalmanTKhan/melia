//--- Melia Script -----------------------------------------------------------
// Future plans
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Lintas.
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

[QuestScript(50233)]
public class Quest50233Script : QuestScript
{
	protected override void Load()
	{
		SetId(50233);
		SetName("Future plans");
		SetDescription("Talk to Priest Lintas");

		AddPrerequisite(new LevelPrerequisite(316));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_4_SQ8"), new CompletedPrerequisite("BRACKEN43_4_SQ10_1"));

		AddDialogHook("BRACKEN434_SUBQ1_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN434_SUBQ1_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN43_4_SQ11_START1", "BRACKEN43_4_SQ11", "Ask about future plans", "Leave your spot"))
		{
			case 1:
				await dialog.Msg("BRACKEN43_4_SQ11_AGREE1");
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

		// Func/BRACKEN434_SUBQ11_COMPLETE;
		await dialog.Msg("FadeOutIN/1000");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

