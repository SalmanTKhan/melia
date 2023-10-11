//--- Melia Script -----------------------------------------------------------
// Refugees of Mishekan Forest(7)
//--- Description -----------------------------------------------------------
// Quest to Talk to Curtis.
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

[QuestScript(50256)]
public class Quest50256Script : QuestScript
{
	protected override void Load()
	{
		SetId(50256);
		SetName("Refugees of Mishekan Forest(7)");
		SetDescription("Talk to Curtis");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "WHITETREES56_1_SQ9_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(327));
		AddPrerequisite(new CompletedPrerequisite("WHITETREES56_1_SQ8"));

		AddObjective("kill0", "Kill 7 Virdney(s) or Blom(s) or Flowlevi(s) or Flowlon(s)", new KillObjective(7, 58565, 58566, 58564, 58563));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));
		AddReward(new ItemReward("Vis", 138321));

		AddDialogHook("WHITETREES561_SUBQ_NPC3", "BeforeStart", BeforeStart);
		AddDialogHook("WHITETREES561_SUBQ_NPC3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WHITETREES561_SUBQ9_START1", "WHITETREES56_1_SQ9", "I give you my word on driving the monsters off of the farm.", "Perhaps, that farm was not meant for you. How about starting anew?"))
		{
			case 1:
				await dialog.Msg("WHITETREES561_SUBQ9_AGREE1");
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

		await dialog.Msg("WHITETREES561_SUBQ9_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

