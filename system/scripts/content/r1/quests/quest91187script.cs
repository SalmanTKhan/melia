//--- Melia Script -----------------------------------------------------------
// The Unredeemed
//--- Description -----------------------------------------------------------
// Quest to Talk to Edmundas in distraught.
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

[QuestScript(91187)]
public class Quest91187Script : QuestScript
{
	protected override void Load()
	{
		SetId(91187);
		SetName("The Unredeemed");
		SetDescription("Talk to Edmundas in distraught");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "EP15_1_F_ABBEY_3_6_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(487));
		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY_3_5"));
		AddPrerequisite(new ItemPrerequisite("EP15_1_F_ABBEY2_MQ_6_ITEM1", 1));

		AddReward(new ExpReward(1800000000, 1800000000));
		AddReward(new ItemReward("Vis", 41379));

		AddDialogHook("EP15_1_F_ABBEY3_AD2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("EP15_1_F_ABBEY3_6_DLG11");
		await dialog.Msg("FadeOutIN/1500");
		dialog.HideNPC("EP15_1_F_ABBEY3_AD2");
		// Func/SCR_EP15_1_END_balloon;
		dialog.UnHideNPC("EP15_1_F_ABBEY_3_SQ1_BOOK1");
		dialog.UnHideNPC("EP15_1_F_ABBEY_3_SQ1_BOOK2");
		dialog.UnHideNPC("EP15_1_F_ABBEY_3_SQ2_BOOK1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.UnHideNPC("EP15_1_F_ABBEY3_AD2");
		dialog.UnHideNPC("GODDESS_RAID_ROZE_PORTAL");
	}
}

