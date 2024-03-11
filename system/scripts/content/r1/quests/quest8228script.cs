//--- Melia Script -----------------------------------------------------------
// Last Mission (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Officer's Spirit.
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

[QuestScript(8228)]
public class Quest8228Script : QuestScript
{
	protected override void Load()
	{
		SetId(8228);
		SetName("Last Mission (3)");
		SetDescription("Talk to the Officer's Spirit");

		AddPrerequisite(new LevelPrerequisite(107));
		AddPrerequisite(new CompletedPrerequisite("KATYN71_MQ_03"));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 2568));

		AddDialogHook("KATYN71_OFFICER", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN71_OFFICER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN71_MQ_04_01", "KATYN71_MQ_04", "I will try it on the monster", "I don't feel so good about it. I won't."))
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

		await dialog.Msg("KATYN71_MQ_04_03");
		await dialog.Msg("FadeOutIN/600");
		dialog.HideNPC("KATYN71_OFFICER");
		dialog.UnHideNPC("KATYN71_OFFICER_AFTER");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

