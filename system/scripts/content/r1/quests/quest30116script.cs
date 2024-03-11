//--- Melia Script -----------------------------------------------------------
// The Power That Even Controls Evil Spirits [Warlock Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with the Warlock Master.
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

[QuestScript(30116)]
public class Quest30116Script : QuestScript
{
	protected override void Load()
	{
		SetId(30116);
		SetName("The Power That Even Controls Evil Spirits [Warlock Advancement]");
		SetDescription("Talk with the Warlock Master");

		AddPrerequisite(new LevelPrerequisite(235));

		AddDialogHook("WARLOCK_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("WARLOCK_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_WARLOCK_7_1_select", "JOB_WARLOCK_7_1", "I am ready", "I will quit since I am scared"))
		{
			case 1:
				await dialog.Msg("JOB_WARLOCK_7_1_agree");
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

		await dialog.Msg("JOB_WARLOCK_7_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

