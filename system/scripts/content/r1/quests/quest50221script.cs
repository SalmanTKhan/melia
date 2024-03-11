//--- Melia Script -----------------------------------------------------------
// Marks of a legend(12)
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

[QuestScript(50221)]
public class Quest50221Script : QuestScript
{
	protected override void Load()
	{
		SetId(50221);
		SetName("Marks of a legend(12)");
		SetDescription("Talk to Mechen");

		AddPrerequisite(new LevelPrerequisite(313));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_3_SQ10"));

		AddDialogHook("BRACKEN433_SUBQ2_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN433_SUBQ2_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN43_3_SQ11_START1", "BRACKEN43_3_SQ11", "Agree to take it to the Fletcher Master", "Tell him to go there himself"))
		{
			case 1:
				await dialog.Msg("BRACKEN43_3_SQ11_AG");
				// Func/SCR_BRACKEN433_SQ11_RUN;
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

		await dialog.Msg("BRACKEN43_3_SQ11_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

