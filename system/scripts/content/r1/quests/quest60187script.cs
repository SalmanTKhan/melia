//--- Melia Script -----------------------------------------------------------
// Find the Hidden Artifacts
//--- Description -----------------------------------------------------------
// Quest to Talk to the Collection Member.
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

[QuestScript(60187)]
public class Quest60187Script : QuestScript
{
	protected override void Load()
	{
		SetId(60187);
		SetName("Find the Hidden Artifacts");
		SetDescription("Talk to the Collection Member");

		AddPrerequisite(new LevelPrerequisite(110));

		AddReward(new ExpReward(49142, 49142));
		AddReward(new ItemReward("expCard6", 2));
		AddReward(new ItemReward("Vis", 2640));

		AddDialogHook("PILGRIM_48_NPC01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM_48_NPC01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM48_RP_1_1", "PILGRIM48_RP_1", "I'll try to find them", "Disregard"))
		{
			case 1:
				dialog.UnHideNPC("PILGRIM48_RP_1_OBJ");
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

		await dialog.Msg("PILGRIM48_RP_1_3");
		dialog.HideNPC("PILGRIM48_RP_1_OBJ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

