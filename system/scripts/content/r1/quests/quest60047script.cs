//--- Melia Script -----------------------------------------------------------
// A Dead End (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Member Grazina.
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

[QuestScript(60047)]
public class Quest60047Script : QuestScript
{
	protected override void Load()
	{
		SetId(60047);
		SetName("A Dead End (1)");
		SetDescription("Talk with Member Grazina");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM311_SQ_04"));

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("Vis", 1640));

		AddDialogHook("PILGRIM311_GRAZINA", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM311_ALINA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM311_SQ_05_01", "PILGRIM311_SQ_05", "I will relay it", "That will be hard"))
		{
			case 1:
				await dialog.Msg("PILGRIM311_SQ_05_01_01");
				await dialog.Msg("FadeOutIN/2500");
				dialog.HideNPC("PILGRIM311_GRAZINA");
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


		return HookResult.Break;
	}
}

