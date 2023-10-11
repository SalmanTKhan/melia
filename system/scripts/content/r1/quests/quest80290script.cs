//--- Melia Script -----------------------------------------------------------
// A Powerful Arrow (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Fletcher Voleta.
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

[QuestScript(80290)]
public class Quest80290Script : QuestScript
{
	protected override void Load()
	{
		SetId(80290);
		SetName("A Powerful Arrow (4)");
		SetDescription("Talk to Fletcher Voleta");

		AddPrerequisite(new LevelPrerequisite(370));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_87_MQ_04"));

		AddObjective("collect0", "Collect 4 Humming Duke Feather(s)", new CollectItemObjective("F_3CMLAKE87_MQ6_ITEM", 4));
		AddDrop("F_3CMLAKE87_MQ6_ITEM", 10f, "Humming_duke");

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 19240));

		AddDialogHook("F_3CMLAKE_87_MQ_05_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_87_MQ_05_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_87_MQ_06_ST", "F_3CMLAKE_87_MQ_06", "Don't worry.", "That's too much to ask of me."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_87_MQ_06_AFST");
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

		if (character.Inventory.HasItem("F_3CMLAKE87_MQ6_ITEM", 4))
		{
			character.Inventory.RemoveItem("F_3CMLAKE87_MQ6_ITEM", 4);
			await dialog.Msg("F_3CMLAKE_87_MQ_06_SU");
			ZoneServer.Instance.World.FindNPC("F_3CMLAKE_87_MQ_05_NPC")?.PlayEffectLocal(character.Connection, "F_light015_violet2", 1f, "TOP");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

