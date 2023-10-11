//--- Melia Script -----------------------------------------------------------
// Too Scared to Sow
//--- Description -----------------------------------------------------------
// Quest to Talk to Riesz.
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

[QuestScript(16330)]
public class Quest16330Script : QuestScript
{
	protected override void Load()
	{
		SetId(16330);
		SetName("Too Scared to Sow");
		SetDescription("Talk to Riesz");

		AddPrerequisite(new LevelPrerequisite(163));

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 4890));

		AddDialogHook("SIAULIAI_46_3_SQ_02_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_46_3_SQ_02_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_46_3_SQ_04_select", "SIAULIAI_46_3_SQ_04", "Alright, I'll help you", "Decline"))
		{
			case 1:
				await dialog.Msg("SIAULIAI_46_3_SQ_04_start_prog");
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

		await dialog.Msg("SIAULIAI_46_3_SQ_04_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

