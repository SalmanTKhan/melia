//--- Melia Script -----------------------------------------------------------
// Hidden Magic Devices
//--- Description -----------------------------------------------------------
// Quest to Talk to Follower Nedluss.
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

[QuestScript(60174)]
public class Quest60174Script : QuestScript
{
	protected override void Load()
	{
		SetId(60174);
		SetName("Hidden Magic Devices");
		SetDescription("Talk to Follower Nedluss");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("CASTLE65_2_MQ05"));

		AddReward(new ExpReward(24571, 24571));
		AddReward(new ItemReward("expCard5", 1));
		AddReward(new ItemReward("Vis", 1600));

		AddDialogHook("CASTLE652_RP_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE652_RP_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE652_RP_1_1", "CASTLE652_RP_1", "I will get rid of it", "That doesn't really matter."))
		{
			case 1:
				dialog.UnHideNPC("CASTLE652_RP_1_OBJ");
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

