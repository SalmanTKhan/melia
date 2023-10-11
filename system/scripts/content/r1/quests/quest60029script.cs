//--- Melia Script -----------------------------------------------------------
// Shutting the Door
//--- Description -----------------------------------------------------------
// Quest to Kupole Audra.
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

[QuestScript(60029)]
public class Quest60029Script : QuestScript
{
	protected override void Load()
	{
		SetId(60029);
		SetName("Shutting the Door");
		SetDescription("Kupole Audra");

		AddPrerequisite(new LevelPrerequisite(151));
		AddPrerequisite(new CompletedPrerequisite("VPRISON511_MQ_05"));

		AddObjective("kill0", "Kill 10 Yellow Yognome(s) or Yellow Egnome(s) or Yellow Gazing Golem(s) or Yellow Moya(s)", new KillObjective(10, 57316, 57315, 57313, 57319));

		AddReward(new ExpReward(852900, 852900));
		AddReward(new ItemReward("expCard8", 4));
		AddReward(new ItemReward("Vis", 4379));

		AddDialogHook("VPRISON511_MQ_AUDRA", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON511_MQ_AUDRA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("VPRISON511_SQ_01_01", "VPRISON511_SQ_01", "I will defeat those demons", "I will be fine"))
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

		await dialog.Msg("VPRISON511_SQ_01_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

