//--- Melia Script -----------------------------------------------------------
// Alongside Assisters(5)
//--- Description -----------------------------------------------------------
// Quest to Go back to Geraldasia..
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

[QuestScript(91006)]
public class Quest91006Script : QuestScript
{
	protected override void Load()
	{
		SetId(91006);
		SetName("Alongside Assisters(5)");
		SetDescription("Go back to Geraldasia.");

		AddPrerequisite(new LevelPrerequisite(100));
		AddPrerequisite(new CompletedPrerequisite("ASSISTOR_TUTO_04"));

		AddReward(new ItemReward("malsuns_emotion88", 3));
		AddReward(new ItemReward("malsuns_emotion95", 3));

		AddDialogHook("NPC_JUNK_SHOP_KLAPEDA", "BeforeStart", BeforeStart);
		AddDialogHook("NPC_JUNK_SHOP_KLAPEDA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ASSISTOR_TUTO_DLG_15", "ASSISTOR_TUTO_05", "Talk about you're experience there.", "The job is not completed yet."))
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

		await dialog.Msg("ASSISTOR_TUTO_DLG_16");
		dialog.ShowHelp("TUTO_ASSISTOR_04");
		// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

