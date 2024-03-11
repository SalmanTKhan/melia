//--- Melia Script -----------------------------------------------------------
// Secrets Hidden Underground (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Paulius.
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

[QuestScript(91057)]
public class Quest91057Script : QuestScript
{
	protected override void Load()
	{
		SetId(91057);
		SetName("Secrets Hidden Underground (2)");
		SetDescription("Talk to Paulius");

		AddPrerequisite(new LevelPrerequisite(460));
		AddPrerequisite(new CompletedPrerequisite("EP13_2_DPRISON2_MQ_1"));

		AddObjective("kill0", "Kill 15 Mokslas Researcher(s) or Mokslas Fumigation(s) or Mokslas Doctor(s)", new KillObjective(15, 59659, 59660, 59661));

		AddReward(new ExpReward(6014994432, 6014994432));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 25));
		AddReward(new ItemReward("Vis", 28980));

		AddDialogHook("EP13_2_DPRISON2_MQ_NPC_3", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_2_DPRISON2_MQ_NPC_FOLLOW_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_2_DPRISON2_MQ_2_DLG1", "EP13_2_DPRISON2_MQ_2", "Alright", "I can not trust Paulius"))
		{
			case 1:
				await dialog.Msg("FadeOutIN/1000");
				dialog.HideNPC("EP13_2_DPRISON2_MQ_NPC_3");
				dialog.HideNPC("EP13_2_DPRISON2_MQ_NPC_2");
				// Func/SCR_EP13_2_DPRISON2_PAJAUTA_SUMMON;
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

		await dialog.Msg("EP13_2_DPRISON2_MQ_2_DLG2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

