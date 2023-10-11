//--- Melia Script -----------------------------------------------------------
// Prepare Camp
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Deputy Commander Kron.
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

[QuestScript(72173)]
public class Quest72173Script : QuestScript
{
	protected override void Load()
	{
		SetId(72173);
		SetName("Prepare Camp");
		SetDescription("Talk to Resistance Deputy Commander Kron");


		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_87_MQ_13"));

		AddObjective("kill0", "Kill 6 Mushuta(s) or Night Panto Mage(s)", new KillObjective(6, 59119, 59110));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 19344));

		AddDialogHook("D_STARTOWER_88_RESISTANCE_SUB_LEADER_KRON_01", "BeforeStart", BeforeStart);
		AddDialogHook("D_STARTOWER_88_RESISTANCE_SUB_LEADER_KRON_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("STARTOWER_88_MQ_10_DLG1", "STARTOWER_88_MQ_10", "Alright", "I need some time to prepare."))
		{
			case 1:
				await dialog.Msg("FadeOutIN/3000");
				dialog.HideNPC("D_STARTOWER_88_RESISTANCE_SUB_LEADER_KRON_01");
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

		await dialog.Msg("STARTOWER_88_MQ_10_DLG3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

