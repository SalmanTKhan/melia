//--- Melia Script -----------------------------------------------------------
// Restrained Souls
//--- Description -----------------------------------------------------------
// Quest to Talk to the Shy Owl Sculpture.
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

[QuestScript(8207)]
public class Quest8207Script : QuestScript
{
	protected override void Load()
	{
		SetId(8207);
		SetName("Restrained Souls");
		SetDescription("Talk to the Shy Owl Sculpture");

		AddPrerequisite(new LevelPrerequisite(109));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 2616));

		AddDialogHook("KATYN72_SECTOR_03", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN72_SECTOR_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN72_MQ_08_01", "KATYN72_MQ_08", "I will check around Nelasve Shore", "Everything will be alright"))
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

		await dialog.Msg("KATYN72_MQ_08_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

