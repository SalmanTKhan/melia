//--- Melia Script -----------------------------------------------------------
// Alongside Assisters(2)
//--- Description -----------------------------------------------------------
// Quest to Go to the Geraldasia of Klaipeda..
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

[QuestScript(91003)]
public class Quest91003Script : QuestScript
{
	protected override void Load()
	{
		SetId(91003);
		SetName("Alongside Assisters(2)");
		SetDescription("Go to the Geraldasia of Klaipeda.");

		AddPrerequisite(new LevelPrerequisite(100));
		AddPrerequisite(new CompletedPrerequisite("ASSISTOR_TUTO_01"));

		AddReward(new ItemReward("Ancient_CardBook_Choice", 1));

		AddDialogHook("NPC_JUNK_SHOP_KLAPEDA", "BeforeStart", BeforeStart);
		AddDialogHook("NPC_JUNK_SHOP_KLAPEDA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ASSISTOR_TUTO_DLG_03", "ASSISTOR_TUTO_02", "Interested.", "Not interested."))
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

		await dialog.Msg("ASSISTOR_TUTO_DLG_06");
		dialog.ShowHelp("TUTO_ASSISTOR_02");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

