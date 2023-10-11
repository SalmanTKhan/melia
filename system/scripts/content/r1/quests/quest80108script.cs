//--- Melia Script -----------------------------------------------------------
// Balancing Magic Circle (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kabbalist Lutas.
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

[QuestScript(80108)]
public class Quest80108Script : QuestScript
{
	protected override void Load()
	{
		SetId(80108);
		SetName("Balancing Magic Circle (1)");
		SetDescription("Talk to Kabbalist Lutas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CORAL_35_2_SQ_10_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(226));
		AddPrerequisite(new CompletedPrerequisite("CORAL_35_2_SQ_9"));

		AddObjective("kill0", "Kill 1 Orange Crabil", new KillObjective(1, MonsterId.Boss_Crabil_Orange));

		AddReward(new ExpReward(3246138, 3246138));
		AddReward(new ItemReward("expCard11", 2));
		AddReward(new ItemReward("Vis", 8136));

		AddDialogHook("CORAL_35_2_LUTAS_3", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_35_2_LUTAS_4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_35_2_SQ_10_start", "CORAL_35_2_SQ_10", "Let's go.", "I can only help so much"))
		{
			case 1:
				dialog.HideNPC("CORAL_35_2_LUTAS_3");
				// Func/CORAL_35_2_SQ_10_NPC;
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

		await dialog.Msg("CORAL_35_2_SQ_10_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

