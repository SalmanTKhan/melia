//--- Melia Script -----------------------------------------------------------
// Thorough Preparations
//--- Description -----------------------------------------------------------
// Quest to Talk to Follower Vaidutis.
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

[QuestScript(60156)]
public class Quest60156Script : QuestScript
{
	protected override void Load()
	{
		SetId(60156);
		SetName("Thorough Preparations");
		SetDescription("Talk to Follower Vaidutis");

		AddPrerequisite(new LevelPrerequisite(44));
		AddPrerequisite(new CompletedPrerequisite("CHAPLE575_MQ_07"));

		AddReward(new ExpReward(8442, 8442));
		AddReward(new ItemReward("expCard3", 1));
		AddReward(new ItemReward("Vis", 660));

		AddDialogHook("CHAPEL_VIRGINIJA", "BeforeStart", BeforeStart);
		AddDialogHook("CHAPEL_VIRGINIJA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHAPLE576_RP_1_1", "CHAPLE576_RP_1", "I'll try to find them", "I wish you good luck."))
		{
			case 1:
				dialog.UnHideNPC("CHAPLE576_RP_1_OBJ");
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

		await dialog.Msg("CHAPLE576_RP_1_3");
		dialog.HideNPC("CHAPLE576_RP_1_OBJ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

