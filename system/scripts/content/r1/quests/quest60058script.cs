//--- Melia Script -----------------------------------------------------------
// An Endless Deal (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Squire Williya.
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

[QuestScript(60058)]
public class Quest60058Script : QuestScript
{
	protected override void Load()
	{
		SetId(60058);
		SetName("An Endless Deal (1)");
		SetDescription("Talk to Squire Williya");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("collect0", "Collect 8 Blue Paint(s)", new CollectItemObjective("PILGRIM313_SQ_01_ITEM", 8));
		AddDrop("PILGRIM313_SQ_01_ITEM", 10f, 58134, 58135, 58136);

		AddReward(new ExpReward(205740, 205740));
		AddReward(new ItemReward("PILGRIM313_SQ_02_ITEM", 1));
		AddReward(new ItemReward("expCard5", 5));
		AddReward(new ItemReward("Vis", 1700));

		AddDialogHook("PILGRIM313_WILLIYA", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM313_ERIKAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM313_SQ_01_01", "PILGRIM313_SQ_01", "Alright, I'll help you", "Tell him that you will think about it"))
		{
			case 1:
				await dialog.Msg("PILGRIM313_SQ_01_01_01");
				// Func/PILGRIM313_SQ_01_RUN;
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

