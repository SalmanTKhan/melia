//--- Melia Script -----------------------------------------------------------
// Preparing for the worst
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

[QuestScript(30156)]
public class Quest30156Script : QuestScript
{
	protected override void Load()
	{
		SetId(30156);
		SetName("Preparing for the worst");
		SetDescription("Talk to Zanas' Soul");

		AddPrerequisite(new LevelPrerequisite(262));
		AddPrerequisite(new CompletedPrerequisite("PRISON_79_MQ_2"));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 17));
		AddReward(new ItemReward("Vis", 10742));

		AddDialogHook("PRISON_79_NPC_2", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON_79_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON_79_MQ_3_select", "PRISON_79_MQ_3", "Show the Teal Magic Stone", "Argue that this is merely complicating things"))
		{
			case 1:
				await dialog.Msg("PRISON_79_MQ_3_agree");
				ZoneServer.Instance.World.FindNPC("PRISON_79_NPC_2")?.PlayEffectLocal(character.Connection, "F_lineup020_blue_mint", 0.6f, "BOT");
				dialog.HideNPC("PRISON_79_NPC_2");
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

		if (character.Inventory.HasItem("PRISON_79_MQ_3_ITEM", 1))
		{
			character.Inventory.RemoveItem("PRISON_79_MQ_3_ITEM", 1);
			await dialog.Msg("PRISON_79_MQ_3_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

