//--- Melia Script -----------------------------------------------------------
// Light the Fire (1)
//--- Description -----------------------------------------------------------
// Quest to Read the epitaph.
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

[QuestScript(8428)]
public class Quest8428Script : QuestScript
{
	protected override void Load()
	{
		SetId(8428);
		SetName("Light the Fire (1)");
		SetDescription("Read the epitaph");

		AddPrerequisite(new LevelPrerequisite(82));

		AddObjective("collect0", "Collect 10 Burning Stone(s)", new CollectItemObjective("ZACHA1F_SQ_01_ITEM", 10));
		AddDrop("ZACHA1F_SQ_01_ITEM", 10f, 401121, 401301);

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1640));

		AddDialogHook("ZACHA1F_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("ZACHA1F_SQ_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ZACHA1F_SQ_01", "ZACHA1F_SQ_01", "Let's go light the stone lantern", "I'll wait a little bit"))
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


		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ZACHA1F_SQ_02");
	}
}

