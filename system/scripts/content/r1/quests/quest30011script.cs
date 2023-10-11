//--- Melia Script -----------------------------------------------------------
// The Spatial Magic Gem of Promise (2)
//--- Description -----------------------------------------------------------
// Quest to Destroy the Barrier Stone.
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

[QuestScript(30011)]
public class Quest30011Script : QuestScript
{
	protected override void Load()
	{
		SetId(30011);
		SetName("The Spatial Magic Gem of Promise (2)");
		SetDescription("Destroy the Barrier Stone");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CATACOMB_04_SQ_04_TRACK", 1000);

		AddPrerequisite(new LevelPrerequisite(191));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_04_SQ_03"));

		AddReward(new ExpReward(713829, 713829));
		AddReward(new ItemReward("expCard10", 5));
		AddReward(new ItemReward("Vis", 5921));

		AddDialogHook("CATACOMB_04_OBJ_03", "BeforeStart", BeforeStart);
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

		if (character.Inventory.HasItem("CATACOMB_04_SQ_04_ITEM", 1))
		{
			character.Inventory.RemoveItem("CATACOMB_04_SQ_04_ITEM", 1);
			ZoneServer.Instance.World.FindNPC("CATACOMB_04_OBJ_01")?.PlayEffectLocal(character.Connection, "F_lineup020_blue_mint", 1f, "BOT");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

