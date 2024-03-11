//--- Melia Script -----------------------------------------------------------
// Security Guard's Favor (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Security Guard.
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

[QuestScript(19380)]
public class Quest19380Script : QuestScript
{
	protected override void Load()
	{
		SetId(19380);
		SetName("Security Guard's Favor (1)");
		SetDescription("Talk to the Security Guard");

		AddPrerequisite(new LevelPrerequisite(78));

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1482));

		AddDialogHook("ROKAS31_SUB", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS31_SUB", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS31_SUB_02_ST", "ROKAS31_SUB_02", "I'll find that chest of yours", "Just ignore it and go your way"))
		{
			case 1:
				await dialog.Msg("ROKAS31_SUB_02_AC");
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

		await dialog.Msg("ROKAS31_SUB_02_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

