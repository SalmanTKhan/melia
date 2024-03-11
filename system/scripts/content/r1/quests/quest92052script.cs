//--- Melia Script -----------------------------------------------------------
// Lost Memories
//--- Description -----------------------------------------------------------
// Quest to Talk to Pajauta.
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

[QuestScript(92052)]
public class Quest92052Script : QuestScript
{
	protected override void Load()
	{
		SetId(92052);
		SetName("Lost Memories");
		SetDescription("Talk to Pajauta");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP13_F_SIAULIAI_3_HQ_01_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(454));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_3_SQ_02"));

		AddDialogHook("EP13_SUB_PAYAUTA_NPC_SIAU_1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_F_SIAULIAI_3_HQ_01_1", "EP13_F_SIAULIAI_3_HQ_01", "I'll accompany you a little more", "Yes"))
		{
			case 1:
				await dialog.Msg("EP13_F_SIAULIAI_3_HQ_01_1_1");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

