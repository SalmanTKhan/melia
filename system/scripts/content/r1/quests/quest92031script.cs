//--- Melia Script -----------------------------------------------------------
// Extinct Mirtinas (4)
//--- Description -----------------------------------------------------------
// Quest to Speak with Goddess Lada.
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

[QuestScript(92031)]
public class Quest92031Script : QuestScript
{
	protected override void Load()
	{
		SetId(92031);
		SetName("Extinct Mirtinas (4)");
		SetDescription("Speak with Goddess Lada");

		AddPrerequisite(new LevelPrerequisite(458));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_5_MQ_04"));

		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 33));

		AddDialogHook("EP13_GODDESS_LADA_ISA", "BeforeStart", BeforeStart);
		AddDialogHook("C_ORSHA_HAMONDAIL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_F_SIAULIAI_5_MQ_05_DLG1", "EP13_F_SIAULIAI_5_MQ_05", "I'll go tell it.", "I still have thing to do here."))
		{
			case 1:
				await dialog.Msg("EP13_F_SIAULIAI_5_MQ_05_DLG2");
				dialog.HideNPC("EP13_GODDESS_LADA_ISA");
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

		await dialog.Msg("EP13_F_SIAULIAI_5_MQ_05_DLG3");
		dialog.UnHideNPC("EP13_GODDESS_LADA4TO5");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

