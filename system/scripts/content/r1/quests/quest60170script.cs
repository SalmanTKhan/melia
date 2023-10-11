//--- Melia Script -----------------------------------------------------------
// Vanished Glory
//--- Description -----------------------------------------------------------
// Quest to Talk with the Royal Mausoleum Guardian.
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

[QuestScript(60170)]
public class Quest60170Script : QuestScript
{
	protected override void Load()
	{
		SetId(60170);
		SetName("Vanished Glory");
		SetDescription("Talk with the Royal Mausoleum Guardian");

		AddPrerequisite(new LevelPrerequisite(81));

		AddObjective("kill0", "Kill 13 Zinutekas(s) or Varv(s) or Boowook(s) or Karas(s) or Zinutekas(s) or Hogma Warrior(s)", new KillObjective(13, 401301, 47347, 401121, 41274, 57740, 41433));

		AddReward(new ExpReward(24571, 24571));
		AddReward(new ItemReward("expCard5", 1));
		AddReward(new ItemReward("Vis", 1620));

		AddDialogHook("ZACHA32_RP_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("ZACHA32_RP_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ZACHA32_RP_1_1", "ZACHA32_RP_1", "Sure, I'll help", "I don't think that's needed,"))
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

		await dialog.Msg("ZACHA32_RP_1_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

