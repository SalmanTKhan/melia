//--- Melia Script -----------------------------------------------------------
// Mage Tower 2nd Floor (5)
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

[QuestScript(8482)]
public class Quest8482Script : QuestScript
{
	protected override void Load()
	{
		SetId(8482);
		SetName("Mage Tower 2nd Floor (5)");
		SetDescription("Talk to Grita");

		AddPrerequisite(new LevelPrerequisite(116));
		AddPrerequisite(new CompletedPrerequisite("FTOWER42_MQ_04"));

		AddReward(new ExpReward(690268, 690268));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 5));
		AddReward(new ItemReward("Vis", 30624));

		AddDialogHook("FTOWER42_G_AI", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER42_G_AI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FTOWER42_MQ_05_01", "FTOWER42_MQ_05", "Go complete the Jewel of Prominence!", "Decline"))
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

		await dialog.Msg("FTOWER42_MQ_05_03");
		dialog.UnHideNPC("FTOWER43_GRITA_01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

