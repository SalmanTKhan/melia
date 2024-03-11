//--- Melia Script -----------------------------------------------------------
// Demon identification
//--- Description -----------------------------------------------------------
// Quest to Talk to Zanas' Soul.
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

[QuestScript(30166)]
public class Quest30166Script : QuestScript
{
	protected override void Load()
	{
		SetId(30166);
		SetName("Demon identification");
		SetDescription("Talk to Zanas' Soul");

		AddPrerequisite(new LevelPrerequisite(265));
		AddPrerequisite(new CompletedPrerequisite("PRISON_80_MQ_2"));

		AddObjective("collect0", "Collect 1 Grinender Seal", new CollectItemObjective("PRISON_80_MQ_3_ITEM", 1));
		AddDrop("PRISON_80_MQ_3_ITEM", 0.5f, 57989, 57930, 57940);

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 10865));

		AddDialogHook("PRISON_80_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON_80_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON_80_MQ_3_select", "PRISON_80_MQ_3", "Say that you will obtain Grinende's Seal", "Say that you will force them to hand it over"))
		{
			case 1:
				await dialog.Msg("PRISON_80_MQ_3_agree");
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

		if (character.Inventory.HasItem("PRISON_80_MQ_3_ITEM", 1))
		{
			character.Inventory.RemoveItem("PRISON_80_MQ_3_ITEM", 1);
			await dialog.Msg("PRISON_80_MQ_3_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

