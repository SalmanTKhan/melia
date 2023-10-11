//--- Melia Script -----------------------------------------------------------
// The Straggler
//--- Description -----------------------------------------------------------
// Quest to Talk with Farm Soldier Upham.
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

[QuestScript(70051)]
public class Quest70051Script : QuestScript
{
	protected override void Load()
	{
		SetId(70051);
		SetName("The Straggler");
		SetDescription("Talk with Farm Soldier Upham");

		AddPrerequisite(new LevelPrerequisite(155));

		AddReward(new ExpReward(852900, 852900));
		AddReward(new ItemReward("expCard8", 4));
		AddReward(new ItemReward("Vis", 4495));

		AddDialogHook("FARM493_SQ_06", "BeforeStart", BeforeStart);
		AddDialogHook("FARM493_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM49_3_SQ_06_1", "FARM49_3_SQ06", "I will take him", "Tell him to go alone"))
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

		await dialog.Msg("FARM49_3_SQ_06_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

