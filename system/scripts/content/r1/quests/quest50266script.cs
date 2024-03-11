//--- Melia Script -----------------------------------------------------------
// A Request from the Shinobi Master
//--- Description -----------------------------------------------------------
// Quest to Talk with the Shinobi Master..
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

[QuestScript(50266)]
public class Quest50266Script : QuestScript
{
	protected override void Load()
	{
		SetId(50266);
		SetName("A Request from the Shinobi Master");
		SetDescription("Talk with the Shinobi Master.");

		AddPrerequisite(new LevelPrerequisite(212));

		AddReward(new ItemReward("SHINOBI_BOOK1", 1));

		AddDialogHook("SHINOBI_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("SHINOBI_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND28_1_HQ1_start1", "TABLELAND28_1_HQ1", "I will follow the trail.", "We should wait."))
		{
			case 1:
				dialog.UnHideNPC("ORCHARD323_HIDDEN_OBJ2");
				await dialog.Msg("BalloonText/TABLELAND281_MSG1/5");
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

		//SCR_TABLELAND28_1_HQ1_ACHIEVE_REWARD
		await dialog.Msg("TABLELAND28_1_HQ1_succ1");
		// Func/TABLE281_HIDDENQ1_COM;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

