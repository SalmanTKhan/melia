//--- Melia Script -----------------------------------------------------------
// Efforts Towards Redemption
//--- Description -----------------------------------------------------------
// Quest to Talk to Follower Bigs.
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

[QuestScript(60175)]
public class Quest60175Script : QuestScript
{
	protected override void Load()
	{
		SetId(60175);
		SetName("Efforts Towards Redemption");
		SetDescription("Talk to Follower Bigs");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("CASTLE65_2_MQ05"));

		AddObjective("collect0", "Collect 12 Concentrated Evil Energy(s)", new CollectItemObjective("CASTLE652_RP_2_ITEM", 12));
		AddDrop("CASTLE652_RP_2_ITEM", 0.8f, 58079, 58075, 58073, 58110);

		AddReward(new ExpReward(24571, 24571));
		AddReward(new ItemReward("expCard5", 1));
		AddReward(new ItemReward("Vis", 1600));

		AddDialogHook("CASTLE652_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE652_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE652_RP_2_1", "CASTLE652_RP_2", "I'll help you", "Decline"))
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

