//--- Melia Script -----------------------------------------------------------
// Monster Leader Operation (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Brockal Himil's Apprentice.
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

[QuestScript(41827)]
public class Quest41827Script : QuestScript
{
	protected override void Load()
	{
		SetId(41827);
		SetName("Monster Leader Operation (1)");
		SetDescription("Talk to Brockal Himil's Apprentice");

		AddPrerequisite(new LevelPrerequisite(391));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_27_2_SQ_5"));

		AddObjective("kill0", "Kill 15 Tooter(s) or Velpod(s) or Monitor Lizard(s)", new KillObjective(15, 59220, 59232, 59254));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 20140));

		AddDialogHook("F_3CMLAKE_27_2_NPC2", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_27_2_NPC2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_27_2_SQ_6_DLG1", "F_3CMLAKE_27_2_SQ_6", "I can take care of some of the monsters.", "Sorry, I'll have to refuse."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_27_2_SQ_6_DLG2");
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

		await dialog.Msg("F_3CMLAKE_27_2_SQ_6_DLG4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("F_3CMLAKE_27_2_SQ_7");
	}
}

