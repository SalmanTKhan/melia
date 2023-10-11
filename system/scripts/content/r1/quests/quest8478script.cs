//--- Melia Script -----------------------------------------------------------
// Mage Tower 2nd Floor (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Grita at Mage Tower 2F.
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

[QuestScript(8478)]
public class Quest8478Script : QuestScript
{
	protected override void Load()
	{
		SetId(8478);
		SetName("Mage Tower 2nd Floor (1)");
		SetDescription("Talk to Grita at Mage Tower 2F");

		AddPrerequisite(new LevelPrerequisite(116));
		AddPrerequisite(new CompletedPrerequisite("FTOWER41_MQ_05"));

		AddReward(new ExpReward(690268, 690268));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 5));
		AddReward(new ItemReward("Vis", 2856));

		AddDialogHook("FTOWER42_GRITA_01", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER42_G_AI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FTOWER42_MQ_01_01", "FTOWER42_MQ_01", "How do you complete the Jewel of Prominence?", "Better go up quickly!"))
		{
			case 1:
				dialog.HideNPC("FTOWER42_GRITA_01");
				await dialog.Msg("FadeOutIN/1000");
				// Func/FTOWER42_MQ_01_RUNNPC;
				await dialog.Msg("FTOWER42_MQ_01_add");
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

		if (character.Inventory.HasItem("FTOWER_FIRE_ESSENCE", 1))
		{
			character.Inventory.RemoveItem("FTOWER_FIRE_ESSENCE", 1);
			await dialog.Msg("FTOWER43_MQ_01_03");
			dialog.HideNPC("FTOWER43_GRITA_01");
			await Task.Delay(500);
			// Func/FTOWER43_MQ_02_RUNNPC;
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FTOWER42_MQ_02");
	}
}

