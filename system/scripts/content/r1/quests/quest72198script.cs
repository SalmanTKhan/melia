//--- Melia Script -----------------------------------------------------------
// To 20F
//--- Description -----------------------------------------------------------
// Quest to Talk to Elder Adaux.
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

[QuestScript(72198)]
public class Quest72198Script : QuestScript
{
	protected override void Load()
	{
		SetId(72198);
		SetName("To 20F");
		SetDescription("Talk to Elder Adaux");

		AddPrerequisite(new LevelPrerequisite(379));
		AddPrerequisite(new CompletedPrerequisite("STARTOWER_90_MQ_70"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 4));

		AddDialogHook("D_STARTOWER_90_SCHAFFENSTAR_ELDER_ADAUX", "BeforeStart", BeforeStart);
		AddDialogHook("D_STARTOWER_90_RESISTANCE_LEADER_BAYL_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("STARTOWER_90_MQ_80_DLG1", "STARTOWER_90_MQ_80", "You can tell me. ", "I don't need any help."))
		{
			case 1:
				// Func/SCR_STARTOWER_90_MQ_80_PROGRESS_TRACK;
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

		//SCR_STARTOWER_90_MQ_80_END
		await dialog.Msg("STARTOWER_90_MQ_80_DLG2");
		await dialog.Msg("FadeOutIN/1000");
		dialog.HideNPC("D_STARTOWER_90_RESISTANCE_LEADER_BAYL_02");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

