//--- Melia Script -----------------------------------------------------------
// To 12F (3)
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

[QuestScript(72189)]
public class Quest72189Script : QuestScript
{
	protected override void Load()
	{
		SetId(72189);
		SetName("To 12F (3)");
		SetDescription("Talk to Resistance Commander Byle");

		AddPrerequisite(new LevelPrerequisite(375));
		AddPrerequisite(new CompletedPrerequisite("STARTOWER_89_MQ_80"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));

		AddDialogHook("D_STARTOWER_89_RESISTANCE_LEADER_BAYL_04", "BeforeStart", BeforeStart);
		AddDialogHook("D_STARTOWER_89_RESISTANCE_LEADER_BAYL_04", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("STARTOWER_89_MQ_90_DLG1", "STARTOWER_89_MQ_90", "Tell me more.", "No, I don't need it."))
		{
			case 1:
				await dialog.Msg("STARTOWER_89_MQ_90_DLG2");
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

		//SCR_STARTOWER_89_MQ_90_END
		await dialog.Msg("STARTOWER_89_MQ_90_DLG3");
		await dialog.Msg("FadeOutIN/1000");
		dialog.HideNPC("D_STARTOWER_89_RESISTANCE_LEADER_BAYL_04");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

