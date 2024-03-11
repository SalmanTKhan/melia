//--- Melia Script -----------------------------------------------------------
// Things You Don't Want to Do
//--- Description -----------------------------------------------------------
// Quest to Talk with Ejuidas.
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

[QuestScript(90126)]
public class Quest90126Script : QuestScript
{
	protected override void Load()
	{
		SetId(90126);
		SetName("Things You Don't Want to Do");
		SetDescription("Talk with Ejuidas");

		AddPrerequisite(new LevelPrerequisite(285));
		AddPrerequisite(new CompletedPrerequisite("MAPLE_25_2_SQ_70"));

		AddDialogHook("MAPLE_25_2_EIVYDAS", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE_25_2_MORKUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MAPLE_25_2_SQ_80_ST", "MAPLE_25_2_SQ_80", "Alright", "I am cut out for that particular job."))
		{
			case 1:
				await dialog.Msg("MAPLE_25_2_SQ_80_AG");
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

		character.AddonMessage(AddonMessage.SHOW_QUEST_SEL_DLG, null, this.QuestId);
		await dialog.Msg("MAPLE_25_2_SQ_80_SU");
		await dialog.Msg("진심으로 위로해준다");
		await dialog.Msg("MAPLE_25_2_SQ_80_SU_2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

