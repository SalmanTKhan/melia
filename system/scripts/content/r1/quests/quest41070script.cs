//--- Melia Script -----------------------------------------------------------
// Restoring the Tombstone (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Eduinas.
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

[QuestScript(41070)]
public class Quest41070Script : QuestScript
{
	protected override void Load()
	{
		SetId(41070);
		SetName("Restoring the Tombstone (2)");
		SetDescription("Talk to Eduinas");

		AddPrerequisite(new LevelPrerequisite(106));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM_36_2_SQ_060"));

		AddObjective("kill0", "Kill 25 Gravegolem(s) or Ticen(s) or Tucen(s) or Hogma Shaman(s)", new KillObjective(25, 58107, 58126, 58127, 58130));

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("PILGRIM_36_2_SQ_070_ITEM_1", 3));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 2544));

		AddDialogHook("PILGRIM_36_2_EDVINAS", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM_36_2_EDVINAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM_36_2_SQ_070_ST", "PILGRIM_36_2_SQ_070", "I'm sorry about it", "Go out now"))
		{
			case 1:
				await dialog.Msg("PILGRIM_36_2_SQ_070_AC");
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

		await dialog.Msg("PILGRIM_36_2_SQ_070_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

