//--- Melia Script -----------------------------------------------------------
// Erecting Tombstones (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Antanas.
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

[QuestScript(41703)]
public class Quest41703Script : QuestScript
{
	protected override void Load()
	{
		SetId(41703);
		SetName("Erecting Tombstones (2)");
		SetDescription("Talk to Antanas");

		AddPrerequisite(new LevelPrerequisite(113));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM_49_SQ_010"));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("PILGRIM_49_SQ_010_ITEM_3", 1));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 2712));

		AddDialogHook("PILGRIM_49_ANTANAS", "BeforeStart", BeforeStart);
		AddDialogHook("ORSHA_BLACKSMITH", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM_49_SQ_013_ST", "PILGRIM_49_SQ_013", "I'll go there", "I will stop helping"))
		{
			case 1:
				await dialog.Msg("PILGRIM_49_SQ_013_AC");
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

		await dialog.Msg("PILGRIM_49_SQ_013_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("PILGRIM_49_SQ_017");
	}
}

