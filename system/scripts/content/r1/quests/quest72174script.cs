//--- Melia Script -----------------------------------------------------------
// Portal Investigation
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Deputy Commander Kron.
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

[QuestScript(72174)]
public class Quest72174Script : QuestScript
{
	protected override void Load()
	{
		SetId(72174);
		SetName("Portal Investigation");
		SetDescription("Talk to Resistance Deputy Commander Kron");

		AddPrerequisite(new LevelPrerequisite(372));
		AddPrerequisite(new CompletedPrerequisite("STARTOWER_88_MQ_10"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 58032));

		AddDialogHook("D_STARTOWER_88_RESISTANCE_SUB_LEADER_KRON_02", "BeforeStart", BeforeStart);
		AddDialogHook("D_STARTOWER_88_RESISTANCE_SUB_LEADER_KRON_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("STARTOWER_88_MQ_20_DLG1", "STARTOWER_88_MQ_20", "I'll go check it out.", "Why don't you get a Resistance member to do it?"))
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

		await dialog.Msg("STARTOWER_88_MQ_20_DLG3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

