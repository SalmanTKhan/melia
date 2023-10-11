//--- Melia Script -----------------------------------------------------------
// Tough Life (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Jaunius.
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

[QuestScript(40110)]
public class Quest40110Script : QuestScript
{
	protected override void Load()
	{
		SetId(40110);
		SetName("Tough Life (2)");
		SetDescription("Talk with Jaunius");

		AddPrerequisite(new LevelPrerequisite(84));
		AddPrerequisite(new CompletedPrerequisite("FARM47_4_SQ_040"));

		AddDialogHook("FARM47_JAUNIUS", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_TADAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM47_4_SQ_050_ST", "FARM47_4_SQ_050", "I have some more questions to ask", "Do not care about it anymore"))
		{
			case 1:
				await dialog.Msg("FARM47_4_SQ_050_AC");
				await Task.Delay(1000);
				// Func/SCR_SETPOS_HIDE_JAUNIUS;
				await Task.Delay(1000);
				// Func/SCR_FARM47_4_SQ_050_ST_MSG;
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

		await dialog.Msg("FARM47_4_SQ_050_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

