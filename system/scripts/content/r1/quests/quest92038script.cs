//--- Melia Script -----------------------------------------------------------
// Attack is the Best Defense (2)
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

[QuestScript(92038)]
public class Quest92038Script : QuestScript
{
	protected override void Load()
	{
		SetId(92038);
		SetName("Attack is the Best Defense (2)");
		SetDescription("Talk to Pajauta");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP13_F_SIAULIAI_1_SQ_05_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(450));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_1_SQ_04"));

		AddReward(new ItemReward("Vis", 27900));
		AddReward(new ItemReward("expCard18", 2));

		AddDialogHook("EP13_SUB_PAYAUTA_NPC_SIAU_1", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_SUB_RECONSTRUCTION_NPC_SIAU_1_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_F_SIAULIAI_1_SQ_05_1", "EP13_F_SIAULIAI_1_SQ_05", "I'll lead the way", "I don't think that's needed,"))
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

		await dialog.Msg("EP13_F_SIAULIAI_1_SQ_05_3");
		// Func/SCR_EP13_F_SIAULIAI_1_SQ_02_RETRY;
		// Func/EP13_F_SIAULIAI_1_SQ_03_HIDE_RUN;
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Go to the Woods of the Linked Bridges");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

