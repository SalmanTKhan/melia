//--- Melia Script -----------------------------------------------------------
// Guardian of the Lake (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Laker Boy.
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

[QuestScript(41836)]
public class Quest41836Script : QuestScript
{
	protected override void Load()
	{
		SetId(41836);
		SetName("Guardian of the Lake (1)");
		SetDescription("Talk to the Laker Boy");

		AddPrerequisite(new LevelPrerequisite(395));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_27_3_SQ_3"));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("F_3CMLAKE_27_3_NPC2", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_27_3_NPC3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_27_3_SQ_4_DLG1", "F_3CMLAKE_27_3_SQ_4", "I can help, sure.", "I'm so tired right now, let me rest for a while."))
		{
			case 1:
				dialog.UnHideNPC("F_3CMLAKE_27_3_NPC3");
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

		await dialog.Msg("F_3CMLAKE_27_3_SQ_4_DLG4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("F_3CMLAKE_27_3_SQ_5");
	}
}

