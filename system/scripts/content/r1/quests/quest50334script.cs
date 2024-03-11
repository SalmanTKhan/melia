//--- Melia Script -----------------------------------------------------------
// To Izoliacjia Plateau
//--- Description -----------------------------------------------------------
// Quest to Read the instruction.
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

[QuestScript(50334)]
public class Quest50334Script : QuestScript
{
	protected override void Load()
	{
		SetId(50334);
		SetName("To Izoliacjia Plateau");
		SetDescription("Read the instruction");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "WTREES22_2_SQ8_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(348));
		AddPrerequisite(new CompletedPrerequisite("WTREES22_2_SQ7"));

		AddObjective("kill0", "Kill 11 Black Hohen Ritter(s) or Black Hohen Gulak(s)", new KillObjective(11, 58846, 58851));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("Vis", 16704));
		AddReward(new ItemReward("expCard15", 1));

		AddDialogHook("WTREES22_2_SUBQ8_IN", "BeforeStart", BeforeStart);
		AddDialogHook("WTREES22_2_SUBQ1_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		dialog.UnHideNPC("WTREES22_3_SUBQ1_NPC1");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "The demons guarding the place have been taken care of.{nl}Go to Narvas Temple through Izoliacjia Plateau.");
		dialog.HideNPC("WTREES22_2_SUBQ1_NPC1");
		dialog.HideNPC("WTREES22_2_SUBQ1_PRE_NPC2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

