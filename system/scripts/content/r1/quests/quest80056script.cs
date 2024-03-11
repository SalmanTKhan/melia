//--- Melia Script -----------------------------------------------------------
// Praying for Their Rest (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Necromancer Lemija.
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

[QuestScript(80056)]
public class Quest80056Script : QuestScript
{
	protected override void Load()
	{
		SetId(80056);
		SetName("Praying for Their Rest (1)");
		SetDescription("Talk with Necromancer Lemija");

		AddPrerequisite(new LevelPrerequisite(208));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_11_1_SQ_04"));

		AddObjective("collect0", "Collect 30 Monster Corpse Piece(s)", new CollectItemObjective("TABLELAND_11_1_SQ_05_PARTS", 30));
		AddDrop("TABLELAND_11_1_SQ_05_PARTS", 10f, 57936, 57937, 57891, 57324);

		AddReward(new ExpReward(541023, 541023));
		AddReward(new ItemReward("expCard11", 3));
		AddReward(new ItemReward("Vis", 7280));

		AddDialogHook("TABLELAND_11_1_LEMIJA2", "BeforeStart", BeforeStart);
		AddDialogHook("TABLELAND_11_1_LEMIJA2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_11_1_SQ_05_start", "TABLELAND_11_1_SQ_05", "Ask what you should do", "Let's avoid before we receive anymore damage"))
		{
			case 1:
				await dialog.Msg("TABLELAND_11_1_SQ_05_agree");
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

		if (character.Inventory.HasItem("TABLELAND_11_1_SQ_05_PARTS", 30))
		{
			character.Inventory.RemoveItem("TABLELAND_11_1_SQ_05_PARTS", 30);
			await dialog.Msg("TABLELAND_11_1_SQ_05_succ");
			ZoneServer.Instance.World.FindNPC("TABLELAND_11_1_LEMIJA2")?.PlayEffectLocal(character.Connection, "F_pc_making_finish_white", 2f, "MID");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

