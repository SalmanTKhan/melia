//--- Melia Script -----------------------------------------------------------
// To Ignas
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

[QuestScript(72208)]
public class Quest72208Script : QuestScript
{
	protected override void Load()
	{
		SetId(72208);
		SetName("To Ignas");
		SetDescription("Talk to Resistance Commander Byle");

		AddPrerequisite(new LevelPrerequisite(382));
		AddPrerequisite(new CompletedPrerequisite("STARTOWER_91_MQ_90"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 4));

		AddDialogHook("D_STARTOWER_91_RESISTANCE_LEADER_BAYL_03", "BeforeStart", BeforeStart);
		AddDialogHook("D_STARTOWER_91_RESISTANCE_LEADER_BAYL_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("STARTOWER_91_MQ_100_DLG1", "STARTOWER_91_MQ_100", "Alright", "Just ask other members of the Resistance to do it."))
		{
			case 1:
				// Func/SCR_STARTOWER_91_MQ_100_START;
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

		//SCR_STARTOWER_91_MQ_100_END
		await dialog.Msg("STARTOWER_91_MQ_100_DLG3");
		await dialog.Msg("FadeOutIN/1000");
		dialog.HideNPC("D_STARTOWER_91_RESISTANCE_LEADER_BAYL_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

