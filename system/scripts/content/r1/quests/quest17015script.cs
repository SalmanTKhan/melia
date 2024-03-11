//--- Melia Script -----------------------------------------------------------
// Too Many Seals (2)
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

[QuestScript(17015)]
public class Quest17015Script : QuestScript
{
	protected override void Load()
	{
		SetId(17015);
		SetName("Too Many Seals (2)");
		SetDescription("Talk to the Sealed Stone");

		AddPrerequisite(new LevelPrerequisite(119));
		AddPrerequisite(new CompletedPrerequisite("FTOWER43_SQ_03"));

		AddObjective("collect0", "Collect 10 Crystal of Restriction(s)", new CollectItemObjective("FTOWER43_SQ_02_01", 10));
		AddDrop("FTOWER43_SQ_02_01", 5f, "Flask_mage");

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 2856));

		AddDialogHook("FTOWER43_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER43_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FTOWER43_SQ_04_ST", "FTOWER43_SQ_04", "Release the seal", "You're busy so just ignore "))
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

		if (character.Inventory.HasItem("FTOWER43_SQ_02_01", 10))
		{
			character.Inventory.RemoveItem("FTOWER43_SQ_02_01", 10);
			await dialog.Msg("FTOWER43_SQ_04_COMP");
			await dialog.Msg("NPCChat/FTOWER43_SQ_03/자유다. 드디어 자유야..");
			ZoneServer.Instance.World.FindNPC("FTOWER43_SQ_03")?.PlayEffectLocal(character.Connection, "F_archer_scarecrow_shot_smoke", 2f, "MID");
			dialog.HideNPC("FTOWER43_SQ_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

