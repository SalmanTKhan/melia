//--- Melia Script -----------------------------------------------------------
// Can-do Spirit
//--- Description -----------------------------------------------------------
// Quest to Talk to Necromancer Drasius.
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

[QuestScript(60181)]
public class Quest60181Script : QuestScript
{
	protected override void Load()
	{
		SetId(60181);
		SetName("Can-do Spirit");
		SetDescription("Talk to Necromancer Drasius");

		AddPrerequisite(new LevelPrerequisite(99));
		AddPrerequisite(new CompletedPrerequisite("REMAIN38_SQ06"));

		AddReward(new ExpReward(49142, 49142));
		AddReward(new ItemReward("expCard6", 2));
		AddReward(new ItemReward("Vis", 1980));

		AddDialogHook("REMAIN38_SQ_DRASIUS", "BeforeStart", BeforeStart);
		AddDialogHook("REMAIN38_SQ_DRASIUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAINS38_RP_1_1", "REMAINS38_RP_1", "Alright", "I don't want to"))
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

		await dialog.Msg("REMAINS38_RP_1_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

