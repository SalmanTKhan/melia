//--- Melia Script -----------------------------------------------------------
// Laimonas' Favor
//--- Description -----------------------------------------------------------
// Quest to Talk to Laimonas.
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

[QuestScript(1015)]
public class Quest1015Script : QuestScript
{
	protected override void Load()
	{
		SetId(1015);
		SetName("Laimonas' Favor");
		SetDescription("Talk to Laimonas");

		AddPrerequisite(new LevelPrerequisite(3));
		AddPrerequisite(new CompletedPrerequisite("SIAUL_WEST_KNIGHT"));

		AddReward(new ExpReward(1000, 1000));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 6));
		AddReward(new ItemReward("Vis", 39));

		AddDialogHook("SIAUL_WEST_LAIMONAS", "BeforeStart", BeforeStart);
		AddDialogHook("SIAUL_WEST_LAIMONAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAUL_WEST_LAIMONAS1_dlg3", "SIAUL_WEST_LAIMONAS1", "What will happen next?", "About the Goddess Statues", "I'm not interested"))
		{
			case 1:
				await dialog.Msg("SIAUL_WEST_LAIMONAS1_dlg1");
				dialog.ShowHelp("MINI_E_STATUE");
				// Func/TUTO_PIP_CLOSE_QUEST;
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("SIAUL_WEST_LAIMONAS1_dlg3_03");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("SIAUL_WEST_LAIMONAS3_dlg1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

