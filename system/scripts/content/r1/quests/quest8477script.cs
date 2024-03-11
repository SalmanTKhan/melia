//--- Melia Script -----------------------------------------------------------
// Agailla Flurry's Barrier
//--- Description -----------------------------------------------------------
// Quest to Talk to Grita.
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

[QuestScript(8477)]
public class Quest8477Script : QuestScript
{
	protected override void Load()
	{
		SetId(8477);
		SetName("Agailla Flurry's Barrier");
		SetDescription("Talk to Grita");

		AddPrerequisite(new LevelPrerequisite(113));
		AddPrerequisite(new CompletedPrerequisite("FTOWER41_MQ_04"));

		AddReward(new ExpReward(690268, 690268));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 5));
		AddReward(new ItemReward("Vis", 29832));

		AddDialogHook("FTOWER41_G_AI", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER41_G_AI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FTOWER41_MQ_05_01", "FTOWER41_MQ_05", "Go activate the Barrier Device.", "I'm not ready yet"))
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

		await dialog.Msg("FTOWER41_MQ_05_03");
		dialog.UnHideNPC("FTOWER42_GRITA_01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

