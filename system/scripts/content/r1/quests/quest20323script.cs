//--- Melia Script -----------------------------------------------------------
// For the Pilgrim (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Alisha.
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

[QuestScript(20323)]
public class Quest20323Script : QuestScript
{
	protected override void Load()
	{
		SetId(20323);
		SetName("For the Pilgrim (3)");
		SetDescription("Talk to Priest Alisha");

		AddPrerequisite(new LevelPrerequisite(158));
		AddPrerequisite(new CompletedPrerequisite("PILGRIMROAD55_SQ02"));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 4582));

		AddDialogHook("PILGRIMROAD55_SQ02", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIMROAD55_SQ02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIMROAD55_SQ06_select01", "PILGRIMROAD55_SQ06", "I will try feeding him the medicine", "Tell her to do that herself"))
		{
			case 1:
				await dialog.Msg("PILGRIMROAD55_SQ06_AG");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("PILGRIMROAD55_SQ06_succ01");
		await dialog.Msg("FadeOutIN/1000");
		dialog.HideNPC("PILGRIMROAD55_SQ02");
		dialog.HideNPC("PILGRIMROAD_CAULDRON");
		dialog.UnHideNPC("PILGRIMROAD55_SQ02_AFTER");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

