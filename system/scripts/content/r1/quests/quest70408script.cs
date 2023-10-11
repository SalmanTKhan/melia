//--- Melia Script -----------------------------------------------------------
// Be Considerate to the Next Person
//--- Description -----------------------------------------------------------
// Quest to Talk to Follower Nuodas.
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

[QuestScript(70408)]
public class Quest70408Script : QuestScript
{
	protected override void Load()
	{
		SetId(70408);
		SetName("Be Considerate to the Next Person");
		SetDescription("Talk to Follower Nuodas");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 20 Pag Ampler(s) or Pag Sawyer(s) or Pag Clamper(s)", new KillObjective(20, 58072, 58074, 58109));

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("Vis", 1444));

		AddDialogHook("CASTLE651_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE651_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE651_SQ_03_start", "CASTLE65_1_SQ03", "I'll help you", "I'm busy with other things"))
		{
			case 1:
				await dialog.Msg("CASTLE651_SQ_03_agree");
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

