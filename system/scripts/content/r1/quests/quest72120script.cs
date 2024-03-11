//--- Melia Script -----------------------------------------------------------
// For Perfect Removal
//--- Description -----------------------------------------------------------
// Quest to Talk to Solcomm.
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

[QuestScript(72120)]
public class Quest72120Script : QuestScript
{
	protected override void Load()
	{
		SetId(72120);
		SetName("For Perfect Removal");
		SetDescription("Talk to Solcomm");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_3CMLAKE262_SQ06_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(336));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE262_SQ05"));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15792));

		AddDialogHook("3CMLAKE_SOLCOMM", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_SOLCOMM", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("3CMLAKE262_SQ06_DLG01", "F_3CMLAKE262_SQ06", "Alright", "It will be too difficult to find."))
		{
			case 1:
				dialog.HideNPC("3CMLAKE_BOMB_DEVICE");
				dialog.UnHideNPC("3CMLAKE262_SQ06_FALSE_STONE01");
				dialog.UnHideNPC("3CMLAKE262_SQ06_FALSE_STONE02");
				dialog.UnHideNPC("3CMLAKE262_SQ06_FALSE_STONE03");
				dialog.UnHideNPC("3CMLAKE262_SQ06_TRUE_STONE");
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

		await dialog.Msg("3CMLAKE262_SQ06_DLG03");
		dialog.HideNPC("3CMLAKE_BLACKMAN03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

