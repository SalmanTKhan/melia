//--- Melia Script -----------------------------------------------------------
// Opening the Barrier (2)
//--- Description -----------------------------------------------------------
// Quest to Soul and conversation of Assistant.
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

[QuestScript(8324)]
public class Quest8324Script : QuestScript
{
	protected override void Load()
	{
		SetId(8324);
		SetName("Opening the Barrier (2)");
		SetDescription("Soul and conversation of Assistant");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "KATYN18_MQ_18_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("KATYN18_MQ_17"));

		AddObjective("kill0", "Kill 6 Evil Spirit(s)", new KillObjective(6, MonsterId.Banshee_Purple));

		AddDialogHook("KATYN18_KEEPER", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN18_OWL_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN18_MQ_18_01", "KATYN18_MQ_18", "I willing to talk of soul in owl image", "Cancel"))
		{
			case 1:
				dialog.UnHideNPC("KATYN18_FENCE");
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

		await dialog.Msg("KATYN18_MQ_18_03");
		dialog.HideNPC("KATYN18_FENCE");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("KATYN18_MQ_19");
	}
}

