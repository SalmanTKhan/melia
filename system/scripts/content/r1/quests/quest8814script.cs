//--- Melia Script -----------------------------------------------------------
// Unnecessary Records
//--- Description -----------------------------------------------------------
// Quest to Talk to Guard Gofden.
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

[QuestScript(8814)]
public class Quest8814Script : QuestScript
{
	protected override void Load()
	{
		SetId(8814);
		SetName("Unnecessary Records");
		SetDescription("Talk to Guard Gofden");

		AddPrerequisite(new LevelPrerequisite(187));

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("Vis", 5797));

		AddDialogHook("FLASH60_GOFDEN", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH60_GOFDEN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH60_SQ_02_01", "FLASH60_SQ_02", "Alright, I'll help you", "About Kostas", "Decline"))
		{
			case 1:
				dialog.UnHideNPC("FLASH60_SQ_02");
				await dialog.Msg("FLASH60_SQ_02_02");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FLASH60_SQ_02_01_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FLASH60_SQ_02_03");
		dialog.HideNPC("FLASH60_SQ_02");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

