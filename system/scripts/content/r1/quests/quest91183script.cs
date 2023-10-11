//--- Melia Script -----------------------------------------------------------
// Oratory Search (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Edmundas.
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

[QuestScript(91183)]
public class Quest91183Script : QuestScript
{
	protected override void Load()
	{
		SetId(91183);
		SetName("Oratory Search (2)");
		SetDescription("Talk to Edmundas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP15_1_F_ABBEY_3_2_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(487));
		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY_3_1"));

		AddReward(new ExpReward(1800000000, 1800000000));
		AddReward(new ItemReward("Vis", 41379));

		AddDialogHook("EP15_1_F_ABBEY3_AD1", "BeforeStart", BeforeStart);
		AddDialogHook("AD3_FOLLOWNPC_CHAT", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP15_1_F_ABBEY_3_2_DLG1", "EP15_1_F_ABBEY_3_2", "I will help", "You're pathetic, I have lost my urge to help you."))
		{
			case 1:
				// Func/SCR_FOLLOWNPC_AD3_SUMMON;
				dialog.HideNPC("EP15_1_F_ABBEY3_AD1");
				await dialog.Msg("EP15_1_F_ABBEY_3_2_DLG2");
				dialog.UnHideNPC("EP15_1_FABBEY3_BLOCK");
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

		await dialog.Msg("EP15_1_F_ABBEY_3_2_DLG3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP15_1_F_ABBEY_3_3");
	}
}

