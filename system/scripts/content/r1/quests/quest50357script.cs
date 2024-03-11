//--- Melia Script -----------------------------------------------------------
// Suspiciously Secretive (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Agailla Flurry Apparition.
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

[QuestScript(50357)]
public class Quest50357Script : QuestScript
{
	protected override void Load()
	{
		SetId(50357);
		SetName("Suspiciously Secretive (2)");
		SetDescription("Talk to Agailla Flurry Apparition");

		AddPrerequisite(new LevelPrerequisite(357));
		AddPrerequisite(new CompletedPrerequisite("ABBEY22_5_SQ2"));

		AddObjective("collect0", "Collect 20 Flesh of Black Hohen Olben(s)", new CollectItemObjective("ABBEY22_5_SUBQ4_ITEM1", 20));
		AddDrop("ABBEY22_5_SUBQ4_ITEM1", 10f, "Hohen_orben_black");

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("Vis", 18207));
		AddReward(new ItemReward("expCard15", 1));

		AddDialogHook("ABBEY225_FLURRY1", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY225_SUBQ2_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY22_5_SUBQ3_START1", "ABBEY22_5_SQ3", "It seems complicated, but I'll try.", "Let's come up with another plan."))
		{
			case 1:
				await dialog.Msg("ABBEY22_5_SUBQ3_AGR1");
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

		if (character.Inventory.HasItem("ABBEY22_5_SUBQ4_ITEM1", 20))
		{
			character.Inventory.RemoveItem("ABBEY22_5_SUBQ4_ITEM1", 20);
			character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Placed the flesh of Black Hohen Olben.");
			ZoneServer.Instance.World.FindNPC("ABBEY225_SUBQ2_NPC1")?.PlayEffectLocal(character.Connection, "F_buff_basic034_pink", 2f, "BOT");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

