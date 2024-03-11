//--- Melia Script -----------------------------------------------------------
// Sculptor's Trial (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Test Instructor Owl.
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

[QuestScript(8332)]
public class Quest8332Script : QuestScript
{
	protected override void Load()
	{
		SetId(8332);
		SetName("Sculptor's Trial (4)");
		SetDescription("Talk to the Test Instructor Owl");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "KATYN18_MQ_26_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("KATYN18_MQ_25"));

		AddObjective("kill0", "Kill 8 Evil Spirit(s)", new KillObjective(8, MonsterId.Banshee_Purple));

		AddDialogHook("KATYN18_TESTER_02", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN18_TESTER_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN18_MQ_26_01", "KATYN18_MQ_26", "Accept", "Cancel"))
		{
			case 1:
				ZoneServer.Instance.World.FindNPC("KATYN18_TESTER_02")?.PlayEffectLocal(character.Connection, "mon_foot_smoke_3");
				dialog.HideNPC("KATYN18_TESTER_02");
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

		await dialog.Msg("KATYN18_MQ_26_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("KATYN18_MQ_27");
	}
}

