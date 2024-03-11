//--- Melia Script -----------------------------------------------------------
// The Spatial Magic Gem of Sacrifice (2)
//--- Description -----------------------------------------------------------
// Quest to Check the Black Shadow.
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

[QuestScript(30013)]
public class Quest30013Script : QuestScript
{
	protected override void Load()
	{
		SetId(30013);
		SetName("The Spatial Magic Gem of Sacrifice (2)");
		SetDescription("Check the Black Shadow");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CATACOMB_04_SQ_06_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(191));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_04_SQ_05"));

		AddObjective("collect0", "Collect 1 Spatial Magic Gem of Offer", new CollectItemObjective("CATACOMB_04_SQ_06_ITEM", 1));
		AddDrop("CATACOMB_04_SQ_06_ITEM", 10f, "boss_Templeshooter_Q1");

		AddReward(new ExpReward(713829, 713829));
		AddReward(new ItemReward("expCard10", 5));
		AddReward(new ItemReward("Vis", 5921));

		AddDialogHook("CATACOMB_04_OBJ_05", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_04_OBJ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("CATACOMB_04_SQ_06_ITEM", 1))
		{
			character.Inventory.RemoveItem("CATACOMB_04_SQ_06_ITEM", 1);
			ZoneServer.Instance.World.FindNPC("CATACOMB_04_OBJ_01")?.PlayEffectLocal(character.Connection, "F_lineup020_blue_mint", 1f, "BOT");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

