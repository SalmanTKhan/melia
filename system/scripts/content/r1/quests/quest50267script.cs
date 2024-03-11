//--- Melia Script -----------------------------------------------------------
// Competitive to the Extreme
//--- Description -----------------------------------------------------------
// Quest to Talk with the Murmillo Master.
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

[QuestScript(50267)]
public class Quest50267Script : QuestScript
{
	protected override void Load()
	{
		SetId(50267);
		SetName("Competitive to the Extreme");
		SetDescription("Talk with the Murmillo Master");

		AddPrerequisite(new LevelPrerequisite(196));

		AddReward(new ItemReward("misc_scrollskulp", 1));

		AddDialogHook("MURMILO_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("MURMILO_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH64_HQ1_start1", "FLASH64_HQ1", "I will try", "I can't do it, sorry."))
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

		await dialog.Msg("FLASH64_HQ1_succ1");
		// Func/FLASH64_HIDDENQ1_FUNC;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

