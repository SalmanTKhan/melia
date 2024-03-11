//--- Melia Script -----------------------------------------------------------
// Guardian of the Lake (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Laker Leader.
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

[QuestScript(41838)]
public class Quest41838Script : QuestScript
{
	protected override void Load()
	{
		SetId(41838);
		SetName("Guardian of the Lake (3)");
		SetDescription("Talk to the Laker Leader");

		AddPrerequisite(new LevelPrerequisite(395));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_27_3_SQ_5"));

		AddObjective("kill0", "Kill 12 Infro Crabil(s) or Frocoli(s)", new KillObjective(12, 59217, 59215));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 20140));

		AddDialogHook("F_3CMLAKE_27_3_NPC3", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_27_3_NPC3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_27_3_SQ_6_DLG1", "F_3CMLAKE_27_3_SQ_6", "Help defeat the monsters.", "It's going to be okay."))
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

		await dialog.Msg("F_3CMLAKE_27_3_SQ_6_DLG3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("F_3CMLAKE_27_3_SQ_7");
	}
}

