//--- Melia Script -----------------------------------------------------------
// Narvas Temple's Barrier (8)
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Aistis.
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

[QuestScript(50342)]
public class Quest50342Script : QuestScript
{
	protected override void Load()
	{
		SetId(50342);
		SetName("Narvas Temple's Barrier (8)");
		SetDescription("Talk to Monk Aistis");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "WTREES22_3_SQ8_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(351));
		AddPrerequisite(new CompletedPrerequisite("WTREES22_3_SQ7"));

		AddObjective("kill0", "Kill 17 Yak Warrior(s) or Yak Druid(s) or Yak Shaman(s) or Yakmap(s) or Yak Mambo(s)", new KillObjective(17, 58847, 58848, 58844, 58854, 58853));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("Vis", 17901));
		AddReward(new ItemReward("expCard15", 1));

		AddDialogHook("WTREES22_3_SUBQ1_NPC5", "BeforeStart", BeforeStart);
		AddDialogHook("WTREES22_3_SUBQ1_NPC5", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WTREES22_3_SUBQ8_START1", "WTREES22_3_SQ8", "I'll wait then", "Let's go straight inside."))
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

		await dialog.Msg("WTREES22_3_SUBQ8_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

