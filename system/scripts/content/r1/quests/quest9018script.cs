//--- Melia Script -----------------------------------------------------------
// Fishing on Land (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Technician Orion.
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

[QuestScript(9018)]
public class Quest9018Script : QuestScript
{
	protected override void Load()
	{
		SetId(9018);
		SetName("Fishing on Land (1)");
		SetDescription("Talk to Technician Orion");

		AddPrerequisite(new LevelPrerequisite(69));

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1311));

		AddDialogHook("ROKAS28_ORION", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS28_TRAP", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS28_SET_TRAP_dlg1", "ROKAS28_SET_TRAP", "I agree", "Better not touch it unless necessary"))
		{
			case 1:
				await dialog.Msg("ROKAS28_SET_TRAP_dlg1_Q");
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
}

