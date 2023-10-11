//--- Melia Script -----------------------------------------------------------
// A Sorrowful Heart
//--- Description -----------------------------------------------------------
// Quest to Talk to Follower Wedge.
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

[QuestScript(70427)]
public class Quest70427Script : QuestScript
{
	protected override void Load()
	{
		SetId(70427);
		SetName("A Sorrowful Heart");
		SetDescription("Talk to Follower Wedge");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("CASTLE65_2_MQ05"));

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("Vis", 1600));

		AddDialogHook("CASTLE652_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE652_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE652_SQ_03_start", "CASTLE65_2_SQ03", "Alright, I'll help you", "I don't have time for it"))
		{
			case 1:
				await dialog.Msg("CASTLE652_SQ_03_agree");
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

