//--- Melia Script -----------------------------------------------------------
// Capturing Bramble (1)
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

[QuestScript(20271)]
public class Quest20271Script : QuestScript
{
	protected override void Load()
	{
		SetId(20271);
		SetName("Capturing Bramble (1)");
		SetDescription("Talk to Believer Jurga");

		AddPrerequisite(new LevelPrerequisite(64));
		AddPrerequisite(new CompletedPrerequisite("HUEVILLAGE_58_4_MQ09"));

		AddReward(new ExpReward(67536, 67536));
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

		switch (await dialog.Select("THORN21_MQ04_select01", "THORN21_MQ04", "I'm ready", "I'm not ready yet"))
		{
			case 1:
				await dialog.Msg("THORN21_MQ04_select_startnpc01");
				await dialog.Msg("THORN21_MQ04_select_startnpc02");
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

		await dialog.Msg("THORN21_MQ04_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

