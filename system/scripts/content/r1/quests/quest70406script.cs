//--- Melia Script -----------------------------------------------------------
// Evidence in Ruins
//--- Description -----------------------------------------------------------
// Quest to Talk to Follower Andrea.
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

[QuestScript(70406)]
public class Quest70406Script : QuestScript
{
	protected override void Load()
	{
		SetId(70406);
		SetName("Evidence in Ruins");
		SetDescription("Talk to Follower Andrea");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(205740, 205740));
		AddReward(new ItemReward("expCard5", 5));
		AddReward(new ItemReward("Vis", 1444));
		AddReward(new ItemReward("Drug_SP2_Q", 30));

		AddDialogHook("CASTLE651_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE651_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE651_SQ_01_start", "CASTLE65_1_SQ01", "I can help you; what kind of information do you need me to gather?", "I don't think I'm skilled enough for that"))
		{
			case 1:
				await dialog.Msg("CASTLE651_SQ_01_agree");
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

