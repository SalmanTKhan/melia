//--- Melia Script -----------------------------------------------------------
// The Search for Rare Materials [Dievdirbys Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with Dievdirbys Submaster.
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

[QuestScript(70328)]
public class Quest70328Script : QuestScript
{
	protected override void Load()
	{
		SetId(70328);
		SetName("The Search for Rare Materials [Dievdirbys Advancement]");
		SetDescription("Talk with Dievdirbys Submaster");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_2_HOPLITE4_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("collect0", "Collect 1 Sparnasman's Horn", new CollectItemObjective("JOB_2_DIEVDIRBYS4_ITEM", 1));
		AddDrop("JOB_2_DIEVDIRBYS4_ITEM", 10f, "boss_Sparnanman_J1");

		AddDialogHook("JOB_2_DIEVDIRBYS_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_DIEVDIRBYS_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_DIEVDIRBYS4_1_1", "JOB_2_DIEVDIRBYS4", "What kind of material is it?", "I have no time for that, sorry"))
		{
			case 1:
				await dialog.Msg("JOB_2_DIEVDIRBYS4_1_2");
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

