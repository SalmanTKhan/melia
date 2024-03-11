//--- Melia Script -----------------------------------------------------------
// Reconstruction of the Blessing (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Albina.
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

[QuestScript(40460)]
public class Quest40460Script : QuestScript
{
	protected override void Load()
	{
		SetId(40460);
		SetName("Reconstruction of the Blessing (2)");
		SetDescription("Talk to Albina");

		AddPrerequisite(new LevelPrerequisite(93));
		AddPrerequisite(new CompletedPrerequisite("FARM47_1_SQ_090"));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 1860));

		AddDialogHook("FARM47_ALBINA", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_ALBINA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM47_1_SQ_100_ST", "FARM47_1_SQ_100", "Alright", "About Albina", "I don't want to do it"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FARM47_1_SQ_100_PRST");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FARM47_1_SQ_100_COMP");
		dialog.HideNPC("FARM47_MAGIC31_D");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

