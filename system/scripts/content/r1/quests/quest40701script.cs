//--- Melia Script -----------------------------------------------------------
// Location of the Metal Plate (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Justas.
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

[QuestScript(40701)]
public class Quest40701Script : QuestScript
{
	protected override void Load()
	{
		SetId(40701);
		SetName("Location of the Metal Plate (2)");
		SetDescription("Talk to Justas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "REMAINS37_3_SQ_041_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(176));
		AddPrerequisite(new CompletedPrerequisite("REMAINS37_3_SQ_040"));

		AddReward(new ExpReward(1256004, 1256004));
		AddReward(new ItemReward("REMAINS37_3_SQ_041__ITEM_1", 1));
		AddReward(new ItemReward("expCard9", 4));
		AddReward(new ItemReward("Vis", 5280));

		AddDialogHook("REMAINS37_3_JUSTAS_AFTER", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS37_3_WELL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAINS37_3_SQ_041_ST", "REMAINS37_3_SQ_041", "I will pull it out", "The reason why the Metal Plate is in the well", "Decline"))
		{
			case 1:
				await dialog.Msg("REMAINS37_3_SQ_041_AC");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
			case 2:
				await dialog.Msg("REMAINS37_3_SQ_041_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		// Func/SCR_REMAINS37_3_SQ_041_DRAW_ANIMATION;
		await Task.Delay(1000);
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You have obtained the Metal Plate!");
		dialog.HideNPC("REMAINS37_3_WELL_ROPE");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

