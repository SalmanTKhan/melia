//--- Melia Script -----------------------------------------------------------
// Endless Gluttony (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Julius.
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

[QuestScript(19490)]
public class Quest19490Script : QuestScript
{
	protected override void Load()
	{
		SetId(19490);
		SetName("Endless Gluttony (3)");
		SetDescription("Talk to Pilgrim Julius");

		AddPrerequisite(new LevelPrerequisite(121));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM46_SQ_050"));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3025));

		AddDialogHook("PILGRIM46_NPC02", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM46_NPC02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM46_SQ_060_ST", "PILGRIM46_SQ_060", "Ask him if there's anything you could help", "Tell him to take some rest now"))
		{
			case 1:
				await dialog.Msg("PILGRIM46_SQ_060_AC");
				dialog.UnHideNPC("PILGRIM46_ACELLU");
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

		await dialog.Msg("PILGRIM46_SQ_060_COMP");
		dialog.HideNPC("PILGRIM46_ACELLU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

