//--- Melia Script -----------------------------------------------------------
// Eat or Be Eaten
//--- Description -----------------------------------------------------------
// Quest to Talk to Follower Bigs.
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

[QuestScript(70426)]
public class Quest70426Script : QuestScript
{
	protected override void Load()
	{
		SetId(70426);
		SetName("Eat or Be Eaten");
		SetDescription("Talk to Follower Bigs");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("CASTLE65_2_MQ05"));

		AddObjective("kill0", "Kill 12 Charog(s) or Pag Nanny(s) or Pag Wheeler(s) or Pag Nat(s)", new KillObjective(12, 58079, 58075, 58073, 58110));

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("Vis", 1600));

		AddDialogHook("CASTLE652_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE652_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE652_SQ_02_start", "CASTLE65_2_SQ02", "I'll defeat some demons around here", "I have no time to help you"))
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


		return HookResult.Break;
	}
}

