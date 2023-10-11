//--- Melia Script -----------------------------------------------------------
// Memorial Service (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Weak Owl Sculpture.
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

[QuestScript(8091)]
public class Quest8091Script : QuestScript
{
	protected override void Load()
	{
		SetId(8091);
		SetName("Memorial Service (1)");
		SetDescription("Talk to the Weak Owl Sculpture");

		AddPrerequisite(new LevelPrerequisite(109));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 2616));

		AddDialogHook("KATYN72_SECTOR_01", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN72_SECTOR_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN72_MQ_01_01", "KATYN72_MQ_01", "I'll collect their remains", "About the Owl Sculpture", "There is no time for that"))
		{
			case 1:
				dialog.UnHideNPC("KATYN72_CORPSE");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("KATYN72_MQ_01_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("KATYN72_MQ_01_03");
		dialog.HideNPC("KATYN72_CORPSE");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("KATYN72_MQ_02");
	}
}

