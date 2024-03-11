//--- Melia Script -----------------------------------------------------------
// Sealed Soul (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sealed Stone.
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

[QuestScript(17010)]
public class Quest17010Script : QuestScript
{
	protected override void Load()
	{
		SetId(17010);
		SetName("Sealed Soul (3)");
		SetDescription("Talk to the Sealed Stone");

		AddPrerequisite(new LevelPrerequisite(116));
		AddPrerequisite(new CompletedPrerequisite("FTOWER42_SQ_03"));

		AddObjective("collect0", "Collect 10 Piece of the Holy Ark(s)", new CollectItemObjective("FTOWER42_SQ_04_01", 10));
		AddDrop("FTOWER42_SQ_04_01", 5f, 57042, 47398, 47461, 47402, 57051);

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 2784));

		AddDialogHook("FTOWER42_SQ_04", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER42_SQ_04", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FTOWER42_SQ_04_ST", "FTOWER42_SQ_04", "Regain the Holy Ark", "Ignore it"))
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

		if (character.Inventory.HasItem("FTOWER42_SQ_04_01", 10))
		{
			character.Inventory.RemoveItem("FTOWER42_SQ_04_01", 10);
			await dialog.Msg("FTOWER42_SQ_04_COMP");
			await dialog.Msg("NPCChat/FTOWER42_SQ_04/드디어..");
			ZoneServer.Instance.World.FindNPC("FTOWER42_SQ_04")?.PlayEffectLocal(character.Connection, "F_archer_scarecrow_shot_smoke", 2f, "MID");
			dialog.HideNPC("FTOWER42_SQ_04");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

