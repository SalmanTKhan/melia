//--- Melia Script -----------------------------------------------------------
// Divide and rule (3)
//--- Description -----------------------------------------------------------
// Quest to Talk with the Baiga's messenger.
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

[QuestScript(92023)]
public class Quest92023Script : QuestScript
{
	protected override void Load()
	{
		SetId(92023);
		SetName("Divide and rule (3)");
		SetDescription("Talk with the Baiga's messenger");

		AddPrerequisite(new LevelPrerequisite(456));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_4_MQ_05"));

		AddReward(new ItemReward("expCard18", 11));
		AddReward(new ItemReward("Vis", 28272));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 33));

		AddDialogHook("EP13_F_SIAULIAI_4_MQ_06_MAIL", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_F_SIAULIAI_4_MQ_06_MAIL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FadeOutIN/1000");
		await dialog.Msg("NoneHideNPC/EP13_F_SIAULIAI_4_MQ_06_MAIL/0/0");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.UnHideNPC("EP13_F_SIAULIAI_4_MQ_06_MAIL");
		// Func/SCR_EP13_F_SIAULIAI_4_MQ_06_GUIDE;
	}
}

