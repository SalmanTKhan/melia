//--- Melia Script -----------------------------------------------------------
// The Teeth of Revenge (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Audra.
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

[QuestScript(60003)]
public class Quest60003Script : QuestScript
{
	protected override void Load()
	{
		SetId(60003);
		SetName("The Teeth of Revenge (1)");
		SetDescription("Talk to Kupole Audra");

		AddPrerequisite(new LevelPrerequisite(151));
		AddPrerequisite(new CompletedPrerequisite("VPRISON511_MQ_01"));

		AddObjective("kill0", "Kill 8 Yellow Yognome(s) or Yellow Egnome(s) or Yellow Gazing Golem(s) or Yellow Moya(s)", new KillObjective(8, 57316, 57315, 57313, 57319));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 8));
		AddReward(new ItemReward("Vis", 4379));

		AddDialogHook("VPRISON511_MQ_AUDRA", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON511_MQ_AUDRA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("VPRISON511_MQ_02_01", "VPRISON511_MQ_02", "I will lend you my power", "I am not competent enough yet"))
		{
			case 1:
				await dialog.Msg("VPRISON511_MQ_02_AG");
				// Func/VPRISON511_MQ_02_HAUBERK_01;
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

		await dialog.Msg("VPRISON511_MQ_02_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

