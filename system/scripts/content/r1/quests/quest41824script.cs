//--- Melia Script -----------------------------------------------------------
// Taking the Lead
//--- Description -----------------------------------------------------------
// Quest to Talk to Brockal Himil.
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

[QuestScript(41824)]
public class Quest41824Script : QuestScript
{
	protected override void Load()
	{
		SetId(41824);
		SetName("Taking the Lead");
		SetDescription("Talk to Brockal Himil");

		AddPrerequisite(new LevelPrerequisite(391));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_27_2_SQ_2"));

		AddObjective("kill0", "Kill 10 Monitor Lizard(s) or Tooter(s)", new KillObjective(10, 59254, 59220));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 20140));

		AddDialogHook("F_3CMLAKE_27_2_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_27_2_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_27_2_SQ_3_DLG1", "F_3CMLAKE_27_2_SQ_3", "I accept.", "Sorry, I'll have to refuse."))
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

		await dialog.Msg("F_3CMLAKE_27_2_SQ_3_DLG3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("F_3CMLAKE_27_2_SQ_4");
	}
}

