//--- Melia Script -----------------------------------------------------------
// To the Government Ruins
//--- Description -----------------------------------------------------------
// Quest to Talk to Revelator Yane.
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

[QuestScript(70443)]
public class Quest70443Script : QuestScript
{
	protected override void Load()
	{
		SetId(70443);
		SetName("To the Government Ruins");
		SetDescription("Talk to Revelator Yane");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "CASTLE65_3_MQ04_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("CASTLE65_3_MQ03"));

		AddDialogHook("CASTLE653_MQ_04_1", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE653_MQ_05_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE653_MQ_04_start", "CASTLE65_3_MQ04", "Let's go now", "Let's get some rest first"))
		{
			case 1:
				dialog.UnHideNPC("CASTLE653_MQ_05_1");
				dialog.UnHideNPC("CASTLE653_MQ_05_2");
				dialog.HideNPC("CASTLE653_MQ_04_1");
				dialog.HideNPC("CASTLE653_MQ_04_2");
				dialog.HideNPC("CASTLE653_MQ_04_4");
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

