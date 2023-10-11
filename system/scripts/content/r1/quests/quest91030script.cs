//--- Melia Script -----------------------------------------------------------
// Headstone on the West of Neryskus Grounds Pathway
//--- Description -----------------------------------------------------------
// Quest to Find the Ancient Headstone and decipher it.
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

[QuestScript(91030)]
public class Quest91030Script : QuestScript
{
	protected override void Load()
	{
		SetId(91030);
		SetName("Headstone on the West of Neryskus Grounds Pathway");
		SetDescription("Find the Ancient Headstone and decipher it");
		SetTrack(QuestStatus.Success, QuestStatus.Success, "EP12_2_F_CASTLE_101_MQ04_2_TRACK_01", "None");

		AddPrerequisite(new LevelPrerequisite(450));
		AddPrerequisite(new CompletedPrerequisite("EP12_2_F_CASTLE_101_MQ04"));

		AddObjective("collect0", "Collect 1 Eyeball of Bower Interferer ", new CollectItemObjective("EP12_2_F_CASTLE_101_MQ04_2_ITEM_01", 1));
		AddObjective("collect1", "Collect 1 Heart of Bower Guillotine", new CollectItemObjective("EP12_2_F_CASTLE_101_MQ04_2_ITEM_02", 1));
		AddObjective("collect2", "Collect 1 Hair of Bower Obstructor", new CollectItemObjective("EP12_2_F_CASTLE_101_MQ04_2_ITEM_03", 1));
		AddObjective("collect3", "Collect 1 Bower Oblivion Core", new CollectItemObjective("EP12_2_F_CASTLE_101_MQ04_2_ITEM_04", 1));
		AddDrop("EP12_2_F_CASTLE_101_MQ04_2_ITEM_01", 2f, "bower_interfere");
		AddDrop("EP12_2_F_CASTLE_101_MQ04_2_ITEM_02", 2f, "bower_guillotine");
		AddDrop("EP12_2_F_CASTLE_101_MQ04_2_ITEM_03", 2f, "bower_obstructer");
		AddDrop("EP12_2_F_CASTLE_101_MQ04_2_ITEM_04", 2f, "bower_oblivion");

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 32));
		AddReward(new ItemReward("Vis", 27900));

		AddDialogHook("EP12_2_F_CASTLE_101_MQ04_2_STONE", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_2_F_CASTLE_101_MQ04_2_STONE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP12_2_F_CASTLE_101_MQ04_2_DLG_1", "EP12_2_F_CASTLE_101_MQ04_2", "I'll find a way", "Let's turn back because it's dangerous"))
		{
			case 1:
				await dialog.Msg("EP12_2_F_CASTLE_101_MQ04_2_DLG_2");
				await dialog.Msg("EP12_2_F_CASTLE_101_MQ04_2_DLG_3");
				await dialog.Msg("EP12_2_F_CASTLE_101_MQ04_2_DLG_4");
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

