//--- Melia Script -----------------------------------------------------------
// Suspicious Bargain (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Commander Byle.
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

[QuestScript(72192)]
public class Quest72192Script : QuestScript
{
	protected override void Load()
	{
		SetId(72192);
		SetName("Suspicious Bargain (2)");
		SetDescription("Talk to Resistance Commander Byle");

		AddPrerequisite(new LevelPrerequisite(379));
		AddPrerequisite(new CompletedPrerequisite("STARTOWER_90_MQ_10"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 19708));

		AddDialogHook("D_STARTOWER_90_RESISTANCE_LEADER_BAYL_01", "BeforeStart", BeforeStart);
		AddDialogHook("D_STARTOWER_90_RESISTANCE_LEADER_BAYL_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("STARTOWER_90_MQ_20_DLG1", "STARTOWER_90_MQ_20", "Alright", "He can't be trusted. I can't."))
		{
			case 1:
				// Func/SCR_STARTOWER_90_MQ_ADAUX_CONNECT_END;
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

		//SCR_D_STARTOWER_90_MQ_20_END
		await dialog.Msg("STARTOWER_90_MQ_20_DLG3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

