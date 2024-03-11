//--- Melia Script -----------------------------------------------------------
// Memorial Service (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Weak Owl Sculpture.
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

[QuestScript(8202)]
public class Quest8202Script : QuestScript
{
	protected override void Load()
	{
		SetId(8202);
		SetName("Memorial Service (3)");
		SetDescription("Talk to the Weak Owl Sculpture");

		AddPrerequisite(new LevelPrerequisite(109));
		AddPrerequisite(new CompletedPrerequisite("KATYN72_MQ_02"));

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

		switch (await dialog.Select("KATYN72_MQ_03_01", "KATYN72_MQ_03", "Where can I get Butterfly Fragrance?", "I can only help so much"))
		{
			case 1:
				await dialog.Msg("KATYN72_MQ_03_04");
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

		await dialog.Msg("KATYN72_MQ_03_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

