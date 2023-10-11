//--- Melia Script -----------------------------------------------------------
// The Road to Klaipeda (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Laimonas.
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

[QuestScript(1018)]
public class Quest1018Script : QuestScript
{
	protected override void Load()
	{
		SetId(1018);
		SetName("The Road to Klaipeda (1)");
		SetDescription("Talk to Laimonas");

		AddPrerequisite(new LevelPrerequisite(4));

		AddObjective("kill0", "Kill 7 Infrorocktor(s)", new KillObjective(7, MonsterId.InfroRocktor));

		AddReward(new ExpReward(500, 500));
		AddReward(new ItemReward("expCard1", 1));
		AddReward(new ItemReward("Vis", 52));

		AddDialogHook("SIAUL_WEST_LAIMONAS", "BeforeStart", BeforeStart);
		AddDialogHook("SIAUL_ST1_ST2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAUL_WEST_LAIMONAS4_dlg1", "SIAUL_WEST_LAIMONAS4", "Sure, I can do that", "Decline"))
		{
			case 1:
				await dialog.Msg("SIAUL_WEST_LAIMONAS4_dlg_a");
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

		await dialog.Msg("SIAUL_WEST_LAIMONAS4_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("SIAUL_WEST_WOOD_SPIRIT");
	}
}

