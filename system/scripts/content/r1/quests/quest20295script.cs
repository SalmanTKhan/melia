//--- Melia Script -----------------------------------------------------------
// Capturing Bramble (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Believer Jurga.
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

[QuestScript(20295)]
public class Quest20295Script : QuestScript
{
	protected override void Load()
	{
		SetId(20295);
		SetName("Capturing Bramble (2)");
		SetDescription("Talk to Believer Jurga");

		AddPrerequisite(new LevelPrerequisite(64));
		AddPrerequisite(new CompletedPrerequisite("THORN21_MQ04"));

		AddReward(new ExpReward(42210, 42210));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 32));
		AddReward(new ItemReward("Vis", 1216));

		AddDialogHook("THORN21_BELIEVER04", "BeforeStart", BeforeStart);
		AddDialogHook("THORN21_BELIEVER04", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN21_MQ03_2_select01", "THORN21_MQ09", "I'll destroy them", "Give me some time"))
		{
			case 1:
				await dialog.Msg("THORN21_MQ03_2_AG");
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

		await dialog.Msg("THORN21_MQ03_2_succ01");
		await dialog.Msg("FadeOutIN/1000");
		dialog.HideNPC("THORN21_BELIEVER04");
		dialog.UnHideNPC("THORN21_BELIEVER04_AFTER");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Move to Giliaii Courtyard");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

