//--- Melia Script -----------------------------------------------------------
// Encounter with Rangda
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Laima.
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

[QuestScript(91022)]
public class Quest91022Script : QuestScript
{
	protected override void Load()
	{
		SetId(91022);
		SetName("Encounter with Rangda");
		SetDescription("Talk to Goddess Laima");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP12_2_F_CASTLE_101_MQ01_TRACK_01", "None");

		AddPrerequisite(new LevelPrerequisite(450));
		AddPrerequisite(new CompletedPrerequisite("EP12_2_F_DACPITAL_104_MQ01"));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 32));

		AddDialogHook("EP12_FINALE_RAIMA02", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_2_F_CASTLE_101_MQ_MASTER_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP12_2_F_CASTLE_101_MQ01_DLG_01", "EP12_2_F_CASTLE_101_MQ01", "I'll follow the fate of the Savior.", "I am afraid yet."))
		{
			case 1:
				// Func/SCR_HIDE_LAIMA_EP12_2;
				// Func/ON_OTHER_PC_EFFECT;
				await dialog.Msg("BalloonText/EP12_2_F_CASTLE_101_MQ01_DLG_3/5");
				// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
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

		await dialog.Msg("EP12_2_F_CASTLE_101_MQ01_DLG_02");
		dialog.HideNPC("EP12_2_F_CASTLE_101_MQ01_TRACK");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP12_2_F_CASTLE_101_MQ02");
	}
}

