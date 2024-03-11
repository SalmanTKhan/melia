//--- Melia Script -----------------------------------------------------------
// Melody of Destruction
//--- Description -----------------------------------------------------------
// Quest to Talk to Florianna of the Orsha's Magic Association.
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

[QuestScript(91179)]
public class Quest91179Script : QuestScript
{
	protected override void Load()
	{
		SetId(91179);
		SetName("Melody of Destruction");
		SetDescription("Talk to Florianna of the Orsha's Magic Association");

		AddPrerequisite(new LevelPrerequisite(485));
		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY2_5"));

		AddReward(new ExpReward(1800000000, 1800000000));
		AddReward(new ItemReward("Vis", 41379));

		AddDialogHook("ORSHA_COLLECTION_SHOP", "BeforeStart", BeforeStart);
		AddDialogHook("EP15_1_FABBEY2_ROZE2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP15_1_F_ABBEY2_6_DLG1", "EP15_1_F_ABBEY2_6", "Hand over the item from Rose.", "I'll be back later."))
		{
			case 1:
				await dialog.Msg("EP15_1_F_ABBEY2_6_DLG2");
				dialog.UnHideNPC("EP15_F_ABBEY2_6_NPC");
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

		await dialog.Msg("EP15_1_F_ABBEY2_6_DLG4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP15_1_F_ABBEY2_7");
	}
}

