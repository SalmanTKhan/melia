//--- Melia Script -----------------------------------------------------------
// Bishop Urbonas' Whereabouts (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Pranas.
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

[QuestScript(60115)]
public class Quest60115Script : QuestScript
{
	protected override void Load()
	{
		SetId(60115);
		SetName("Bishop Urbonas' Whereabouts (1)");
		SetDescription("Talk with Priest Pranas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PRISON621_MQ_01_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ORSHA_MQ2_03"));

		AddDialogHook("SIAULIAI11RE_PRANAS_1", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON621_PRANAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON621_MQ_01_01", "PRISON621_MQ_01", "Let's see inside", "I am not ready yet"))
		{
			case 1:
				await dialog.Msg("PRISON621_MQ_01_01_01");
				await dialog.Msg("FadeOutIN/2500");
				dialog.HideNPC("SIAU11RE_TORNAVA");
				dialog.HideNPC("SIAU11RE_DARAMAUS");
				dialog.HideNPC("SIAULIAI11RE_PRANAS_1");
				dialog.UnHideNPC("PRISON621_MQ_02_WALL");
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

