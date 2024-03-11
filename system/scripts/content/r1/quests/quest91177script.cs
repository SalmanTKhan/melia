//--- Melia Script -----------------------------------------------------------
// Blurry Trail (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Rose.
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

[QuestScript(91177)]
public class Quest91177Script : QuestScript
{
	protected override void Load()
	{
		SetId(91177);
		SetName("Blurry Trail (2)");
		SetDescription("Talk to Rose");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP15_1_F_ABBEY2_4_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(485));
		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY2_3"));

		AddReward(new ExpReward(1800000000, 1800000000));
		AddReward(new ItemReward("Vis", 41379));

		AddDialogHook("EP15_1_FABBEY2_ROZE1", "BeforeStart", BeforeStart);
		AddDialogHook("EP15_1_FABBEY2_ROZE2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP15_1_F_ABBEY2_4_DLG1", "EP15_1_F_ABBEY2_4", "Alright", "You still need to rest."))
		{
			case 1:
				// Func/SCR_EP15_1_ABBEY2_SUMMON_ABANDON;
				dialog.UnHideNPC("EP15_1_FABBEY2_MQ4_BOWER01");
				dialog.UnHideNPC("EP15_1_FABBEY2_MQ4_BOWER02");
				dialog.UnHideNPC("EP15_1_FABBEY2_MQ4_BOWER03");
				dialog.UnHideNPC("EP15_1_FABBEY2_MQ4_BOWER04");
				dialog.HideNPC("EP15_1_FABBEY2_AD1");
				dialog.HideNPC("EP15_1_FABBEY2_ROZE1");
				await dialog.Msg("EP15_1_F_ABBEY2_4_DLG2");
				dialog.UnHideNPC("EP15_1_GLOVECUPSULE");
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

		await dialog.Msg("EP15_1_F_ABBEY2_4_DLG3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP15_1_F_ABBEY2_5");
	}
}

