//--- Melia Script -----------------------------------------------------------
// What Kind of Sin (2)
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

[QuestScript(17013)]
public class Quest17013Script : QuestScript
{
	protected override void Load()
	{
		SetId(17013);
		SetName("What Kind of Sin (2)");
		SetDescription("Talk to the Sealed Stone");

		AddPrerequisite(new LevelPrerequisite(119));
		AddPrerequisite(new CompletedPrerequisite("FTOWER43_SQ_01"));

		AddObjective("collect0", "Collect 10 Sealed Stone's Voice(s)", new CollectItemObjective("FTOWER43_SQ_01_01", 10));
		AddDrop("FTOWER43_SQ_01_01", 5f, "arma");

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 2856));

		AddDialogHook("FTOWER43_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER43_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FTOWER43_SQ_02_ST", "FTOWER43_SQ_02", "Regain him his voice", "Ignore it"))
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

		if (character.Inventory.HasItem("FTOWER43_SQ_01_01", 10))
		{
			character.Inventory.RemoveItem("FTOWER43_SQ_01_01", 10);
			await dialog.Msg("FTOWER43_SQ_02_COMP");
			await dialog.Msg("NPCChat/FTOWER43_SQ_01/이걸로 됐어..");
			ZoneServer.Instance.World.FindNPC("FTOWER43_SQ_01")?.PlayEffectLocal(character.Connection, "F_archer_scarecrow_shot_smoke", 2f, "BOT");
			dialog.HideNPC("FTOWER43_SQ_01");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

