//--- Melia Script -----------------------------------------------------------
// How to beat stronger foes(1)
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

[QuestScript(30149)]
public class Quest30149Script : QuestScript
{
	protected override void Load()
	{
		SetId(30149);
		SetName("How to beat stronger foes(1)");
		SetDescription("Talk to Zanas' Soul");

		AddPrerequisite(new LevelPrerequisite(259));
		AddPrerequisite(new CompletedPrerequisite("PRISON_78_MQ_4"));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 17));
		AddReward(new ItemReward("Vis", 10360));

		AddDialogHook("PRISON_78_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON_78_NPC_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON_78_MQ_5_select", "PRISON_78_MQ_5", "Say that you will retrieve the Magic Control Scrolls", "Say that you do not need such things"))
		{
			case 1:
				await dialog.Msg("PRISON_78_MQ_5_agree");
				ZoneServer.Instance.World.FindNPC("PRISON_78_NPC_1")?.PlayEffectLocal(character.Connection, "F_lineup020_blue_mint", 0.6f, "BOT");
				dialog.HideNPC("PRISON_78_NPC_1");
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

		if (character.Inventory.HasItem("PRISON_78_MQ_5_ITEM", 1))
		{
			character.Inventory.RemoveItem("PRISON_78_MQ_5_ITEM", 1);
			await dialog.Msg("PRISON_78_MQ_5_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

