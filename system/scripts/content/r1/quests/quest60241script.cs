//--- Melia Script -----------------------------------------------------------
// The First Guest's Role (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Neringa.
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

[QuestScript(60241)]
public class Quest60241Script : QuestScript
{
	protected override void Load()
	{
		SetId(60241);
		SetName("The First Guest's Role (2)");
		SetDescription("Talk to Neringa");

		AddPrerequisite(new LevelPrerequisite(335));
		AddPrerequisite(new CompletedPrerequisite("FANTASYLIB481_MQ_PRE_1"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("WTREE212_NERINGA_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("FLIBRARY481_VIVORA_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FANTASYLIB481_MQ_PRE_2_1", "FANTASYLIB481_MQ_PRE_2", "Say that you will do it", "I won't do it."))
		{
			case 1:
				dialog.HideNPC("WTREE212_NERINGA_NPC");
				await dialog.Msg("FadeOutIN/2000");
				dialog.UnHideNPC("FLIBRARY481_NERINGA_NPC");
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

		await dialog.Msg("FANTASYLIB481_MQ_PRE_2_3");
		dialog.HideNPC("FLIBRARY481_VIVORA_NPC");
		await dialog.Msg("FadeOutIN/2000");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

