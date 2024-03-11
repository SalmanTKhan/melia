//--- Melia Script -----------------------------------------------------------
// Prison Movement(1)
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

[QuestScript(30167)]
public class Quest30167Script : QuestScript
{
	protected override void Load()
	{
		SetId(30167);
		SetName("Prison Movement(1)");
		SetDescription("Talk to Zanas' Soul");

		AddPrerequisite(new LevelPrerequisite(265));
		AddPrerequisite(new CompletedPrerequisite("PRISON_80_MQ_3"));

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

		switch (await dialog.Select("PRISON_80_MQ_4_select", "PRISON_80_MQ_4", "Say that you want to deal a blow to the Demons", "Say that the Demons can't be that stupid"))
		{
			case 1:
				await dialog.Msg("PRISON_80_MQ_4_agree");
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

		if (character.Inventory.HasItem("PRISON_80_MQ_4_ITEM", 2))
		{
			character.Inventory.RemoveItem("PRISON_80_MQ_4_ITEM", 2);
			await dialog.Msg("PRISON_80_MQ_4_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

