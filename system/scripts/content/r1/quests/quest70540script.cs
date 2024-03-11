//--- Melia Script -----------------------------------------------------------
// Falsely Accused Murderer
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Vados.
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

[QuestScript(70540)]
public class Quest70540Script : QuestScript
{
	protected override void Load()
	{
		SetId(70540);
		SetName("Falsely Accused Murderer");
		SetDescription("Talk to Pilgrim Vados");

		AddPrerequisite(new LevelPrerequisite(265));

		AddDialogHook("PILGRIM414_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM414_SQ_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM414_SQ_01_start", "PILGRIM41_4_SQ01", "Ask about what is happening", "Back off and stay out of trouble"))
		{
			case 1:
				await dialog.Msg("PILGRIM414_SQ_01_agree");
				await dialog.Msg("BalloonText/PILGRIM41_4_SQ01_DLG/5");
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

		await dialog.Msg("PILGRIM414_SQ_01_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

