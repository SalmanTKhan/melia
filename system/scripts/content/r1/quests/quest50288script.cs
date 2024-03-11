//--- Melia Script -----------------------------------------------------------
// My Best Buddy
//--- Description -----------------------------------------------------------
// Quest to Talk to the Hackapell Master.
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

[QuestScript(50288)]
public class Quest50288Script : QuestScript
{
	protected override void Load()
	{
		SetId(50288);
		SetName("My Best Buddy");
		SetDescription("Talk to the Hackapell Master");

		AddPrerequisite(new LevelPrerequisite(176));

		AddReward(new ItemReward("Gacha_H_004", 1));

		AddDialogHook("HACKAPELL_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("HACKAPELL_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAINS373_HQ1_start1", "REMAINS373_HQ1", "I'll prove it to you!", "Do not do it"))
		{
			case 1:
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

		await dialog.Msg("REMAINS373_HQ1_succ1");
		// Func/REMAINS373_HIDDENQ1_COMP;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

