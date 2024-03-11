//--- Melia Script -----------------------------------------------------------
// Alongside Assisters(1)
//--- Description -----------------------------------------------------------
// Quest to Go to the Geraldasia of Klaipeda..
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

[QuestScript(91002)]
public class Quest91002Script : QuestScript
{
	protected override void Load()
	{
		SetId(91002);
		SetName("Alongside Assisters(1)");
		SetDescription("Go to the Geraldasia of Klaipeda.");

		AddPrerequisite(new LevelPrerequisite(100));

		AddDialogHook("NPC_JUNK_SHOP_KLAPEDA", "BeforeStart", BeforeStart);
		AddDialogHook("NPC_JUNK_SHOP_KLAPEDA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ASSISTOR_TUTO_DLG_01", "ASSISTOR_TUTO_01", "Interested.", "Not interested."))
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

		//SCR_ASSISTOR_TUTO_01_CLEAR_TX
		// Func/SCR_AQ_TEAMCLEAR;
		await dialog.Msg("ASSISTOR_TUTO_DLG_02");
		dialog.ShowHelp("TUTO_ASSISTOR_01");
		// Func/SCR_ASSISTOR_TUTO_01_UIOPEN/0;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

