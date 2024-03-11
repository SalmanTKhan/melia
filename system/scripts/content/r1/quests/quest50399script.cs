//--- Melia Script -----------------------------------------------------------
// What was in the storage device (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Wizard Aldoni.
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

[QuestScript(50399)]
public class Quest50399Script : QuestScript
{
	protected override void Load()
	{
		SetId(50399);
		SetName("What was in the storage device (1)");
		SetDescription("Talk to Wizard Aldoni");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_NICOPOLIS_81_3_SQ_01_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(387));

		AddObjective("kill0", "Kill 9 Slime Wizard(s) or Slime Witch(s)", new KillObjective(9, 59161, 59151));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 31000));

		AddDialogHook("NICO813_SUBQ_NPC1_1", "BeforeStart", BeforeStart);
		AddDialogHook("NICO813_SUBQ_NPC1_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("NICO813_SUBQ01_START1", "F_NICOPOLIS_81_3_SQ_01", "Alright, I'll help you", "Leave this place"))
		{
			case 1:
				await dialog.Msg("NICO813_SUBQ01_AGREE1");
				dialog.UnHideNPC("NICO813_SUBQ_NPC1_2");
				await dialog.Msg("FadeOutIN/1000");
				dialog.HideNPC("NICO813_SUBQ_NPC1_1");
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

		await dialog.Msg("NICO813_SUBQ01_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

