//--- Melia Script -----------------------------------------------------------
// The Final Battle (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Commander Byle.
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

[QuestScript(72209)]
public class Quest72209Script : QuestScript
{
	protected override void Load()
	{
		SetId(72209);
		SetName("The Final Battle (1)");
		SetDescription("Talk to Resistance Commander Byle");

		AddPrerequisite(new LevelPrerequisite(386));
		AddPrerequisite(new CompletedPrerequisite("STARTOWER_91_MQ_100"));

		AddObjective("kill0", "Kill 8 Pipi(s) or Piang(s) or Vespera(s) or Vesperia(s)", new KillObjective(8, 59111, 59118, 59112, 59155));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 4));
		AddReward(new ItemReward("Vis", 20458));

		AddDialogHook("D_STARTOWER_92_RESISTANCE_LEADER_BAYL_01", "BeforeStart", BeforeStart);
		AddDialogHook("D_STARTOWER_92_RESISTANCE_LEADER_BAYL_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("STARTOWER_92_MQ_10_DLG1", "STARTOWER_92_MQ_10", "Alright", "We should join the other Resistance members."))
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

		//SCR_STARTOWER_92_MQ_10_END
		await dialog.Msg("STARTOWER_92_MQ_10_DLG3");
		await dialog.Msg("FadeOutIN/1000");
		dialog.HideNPC("D_STARTOWER_92_RESISTANCE_LEADER_BAYL_01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

