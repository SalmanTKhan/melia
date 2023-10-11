//--- Melia Script -----------------------------------------------------------
// Helping A Beginner Revelator
//--- Description -----------------------------------------------------------
// Quest to Talk to Serapinas.
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

[QuestScript(41630)]
public class Quest41630Script : QuestScript
{
	protected override void Load()
	{
		SetId(41630);
		SetName("Helping A Beginner Revelator");
		SetDescription("Talk to Serapinas");

		AddPrerequisite(new LevelPrerequisite(110));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM_48_SQ_020"));

		AddReward(new ExpReward(294852, 294852));
		AddReward(new ItemReward("expCard6", 6));
		AddReward(new ItemReward("Vis", 2640));

		AddDialogHook("PILGRIM_48_SERAPINAS", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM_48_SERAPINAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM_48_SQ_030_ST", "PILGRIM_48_SQ_030", "I'll try to do it", "Decline"))
		{
			case 1:
				await dialog.Msg("PILGRIM_48_SQ_030_AC");
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

		await dialog.Msg("PILGRIM_48_SQ_030_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

