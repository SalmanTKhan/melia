//--- Melia Script -----------------------------------------------------------
// The Road to Klaipeda (2)
//--- Description -----------------------------------------------------------
// Quest to Go to Klaipeda.
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

[QuestScript(1019)]
public class Quest1019Script : QuestScript
{
	protected override void Load()
	{
		SetId(1019);
		SetName("The Road to Klaipeda (2)");
		SetDescription("Go to Klaipeda");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SIAUL_WEST_WOOD_SPIRIT_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(4));
		AddPrerequisite(new CompletedPrerequisite("SIAUL_WEST_LAIMONAS4"));

		AddObjective("kill0", "Kill 1 Rocktortuga", new KillObjective(1, MonsterId.Boss_Rocktortuga));

		AddReward(new ExpReward(1500, 1500));
		AddReward(new ItemReward("expCard1", 3));
		AddReward(new ItemReward("Vis", 728));

		AddDialogHook("SIAUL_ST1_ST2", "BeforeStart", BeforeStart);
		AddDialogHook("SIAUL_ST1_ST2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAUL_WEST_WOOD_SPIRIT_ST", "SIAUL_WEST_WOOD_SPIRIT", "I'll lend my strength to you", "Enter Klaipeda"))
		{
			case 1:
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

		dialog.UnHideNPC("JOB_HOPLITE2_NPC");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

