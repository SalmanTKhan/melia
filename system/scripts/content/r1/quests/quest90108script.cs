//--- Melia Script -----------------------------------------------------------
// Autumn Leaves (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Forest Keeper Brunonas.
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

[QuestScript(90108)]
public class Quest90108Script : QuestScript
{
	protected override void Load()
	{
		SetId(90108);
		SetName("Autumn Leaves (1)");
		SetDescription("Talk to Forest Keeper Brunonas");

		AddPrerequisite(new LevelPrerequisite(282));

		AddObjective("kill0", "Kill 8 Rhodenag(s) or Rhodetad(s) or Rhodenabean(s)", new KillObjective(8, 58539, 58540, 58538));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11844));

		AddDialogHook("MAPLE_25_1_BRONIUS", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE_25_1_BRONIUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MAPLE_25_1_SQ_10_ST", "MAPLE_25_1_SQ_10", "Alright, I'll help you", "I'm not interested"))
		{
			case 1:
				await dialog.Msg("MAPLE_25_1_SQ_10_AG");
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

		await dialog.Msg("MAPLE_25_1_SQ_10_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

