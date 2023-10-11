//--- Melia Script -----------------------------------------------------------
// Retaking the Altar
//--- Description -----------------------------------------------------------
// Quest to Talk to Loremaster Verta.
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

[QuestScript(90074)]
public class Quest90074Script : QuestScript
{
	protected override void Load()
	{
		SetId(90074);
		SetName("Retaking the Altar");
		SetDescription("Talk to Loremaster Verta");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CORAL_32_2_SQ_6_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(235));
		AddPrerequisite(new CompletedPrerequisite("CORAL_32_2_SQ_5"));

		AddObjective("kill0", "Kill 1 Crabil", new KillObjective(1, MonsterId.Boss_Crabil));

		AddReward(new ExpReward(5910366, 5910366));
		AddReward(new ItemReward("Vis", 8460));
		AddReward(new ItemReward("expCard12", 2));

		AddDialogHook("CORAL_32_2_BERTA3", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_32_2_BERTA2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_32_2_SQ_6_ST", "CORAL_32_2_SQ_6", "I'll get rid of that Crabil.", "I need some time to prepare."))
		{
			case 1:
				await dialog.Msg("CORAL_32_2_SQ_6_AG");
				dialog.UnHideNPC("CORAL_32_2_JURATEALTAR");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("CORAL_32_2_SQ_6_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

