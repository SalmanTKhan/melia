//--- Melia Script -----------------------------------------------------------
// Stuffy Colleagues
//--- Description -----------------------------------------------------------
// Quest to Talk to Merchant Dolonas.
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

[QuestScript(60186)]
public class Quest60186Script : QuestScript
{
	protected override void Load()
	{
		SetId(60186);
		SetName("Stuffy Colleagues");
		SetDescription("Talk to Merchant Dolonas");

		AddPrerequisite(new LevelPrerequisite(106));

		AddObjective("kill0", "Kill 12 Ticen(s) or Tucen(s) or Gravegolem(s) or Hogma Shaman(s)", new KillObjective(12, 58126, 58127, 58107, 58130));

		AddReward(new ExpReward(49142, 49142));
		AddReward(new ItemReward("expCard6", 2));
		AddReward(new ItemReward("Vis", 2544));

		AddDialogHook("PILGRIM362_RP_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM362_RP_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM362_RP_1_1", "PILGRIM362_RP_1", "I can help you a little.", "Ignore"))
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

		await dialog.Msg("PILGRIM362_RP_1_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

