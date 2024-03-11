//--- Melia Script -----------------------------------------------------------
// Preparation (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Grave Robber Amanda.
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

[QuestScript(50081)]
public class Quest50081Script : QuestScript
{
	protected override void Load()
	{
		SetId(50081);
		SetName("Preparation (1)");
		SetDescription("Talk to Grave Robber Amanda");

		AddPrerequisite(new LevelPrerequisite(214));
		AddPrerequisite(new CompletedPrerequisite("UNDERFORTRESS_69_MQ020"));

		AddObjective("collect0", "Collect 4 Demon's Blood(s)", new CollectItemObjective("UNDER69_MQ3_ITEM01", 4));
		AddDrop("UNDER69_MQ3_ITEM01", 10f, "Templeslave_blue");

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 24));
		AddReward(new ItemReward("Vis", 7490));

		AddDialogHook("AMANDA_69_2", "BeforeStart", BeforeStart);
		AddDialogHook("UNDER69_MQ3_DEVICE_REPAIR", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("UNDER_69_MQ030_startnpc01", "UNDERFORTRESS_69_MQ030", "How do you activate the magic circle?", "Do it later"))
		{
			case 1:
				await dialog.Msg("UNDER_69_MQ030_AG");
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

		if (character.Inventory.HasItem("UNDER69_MQ3_ITEM01", 4))
		{
			character.Inventory.RemoveItem("UNDER69_MQ3_ITEM01", 4);
			await dialog.Msg("FadeOutIN/1000");
			character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "The foundation stone is activating!");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

