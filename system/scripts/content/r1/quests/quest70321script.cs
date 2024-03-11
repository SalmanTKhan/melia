//--- Melia Script -----------------------------------------------------------
// Reclaiming Lost Items [Hoplite Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Hoplite Master.
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

[QuestScript(70321)]
public class Quest70321Script : QuestScript
{
	protected override void Load()
	{
		SetId(70321);
		SetName("Reclaiming Lost Items [Hoplite Advancement]");
		SetDescription("Talk to the Hoplite Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_2_HOPLITE4_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("collect0", "Collect 1 Aidas' Lost Spear Tip", new CollectItemObjective("JOB_2_HOPLITE4_ITEM", 1));
		AddDrop("JOB_2_HOPLITE4_ITEM", 10f, "boss_Sparnanman_J1");

		AddDialogHook("JOB_2_HOPLITE_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_HOPLITE_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_HOPLITE4_1_1", "JOB_2_HOPLITE4", "Of course", "It's not a lot"))
		{
			case 1:
				await dialog.Msg("JOB_2_HOPLITE4_1_2");
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


		return HookResult.Break;
	}
}

