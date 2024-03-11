//--- Melia Script -----------------------------------------------------------
// The Corrupted Monster
//--- Description -----------------------------------------------------------
// Quest to Talk with Agent Notres.
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

[QuestScript(60109)]
public class Quest60109Script : QuestScript
{
	protected override void Load()
	{
		SetId(60109);
		SetName("The Corrupted Monster");
		SetDescription("Talk with Agent Notres");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("collect0", "Collect 7 Corrupted Blood(s)", new CollectItemObjective("SIAU11RE_SQ_05_ITEM", 7));
		AddDrop("SIAU11RE_SQ_05_ITEM", 7f, 58009, 58007, 58088, 41294);

		AddReward(new ExpReward(2686, 2686));
		AddReward(new ItemReward("expCard2", 1));
		AddReward(new ItemReward("Vis", 169));

		AddDialogHook("SIAULIAI11RE_NOTORESU", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI11RE_NOTORESU", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAU11RE_SQ_05_01", "SIAU11RE_SQ_05", "I'll collect it", "Tell her that there is a more emergent issue"))
		{
			case 1:
				await dialog.Msg("SIAU11RE_SQ_05_01_AG");
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

