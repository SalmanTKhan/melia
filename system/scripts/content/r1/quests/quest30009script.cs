//--- Melia Script -----------------------------------------------------------
// The Spatial Magic Gem of Contract (2)
//--- Description -----------------------------------------------------------
// Quest to Activate the Magic Field of Preservation at the Shrine of Remembrance.
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

[QuestScript(30009)]
public class Quest30009Script : QuestScript
{
	protected override void Load()
	{
		SetId(30009);
		SetName("The Spatial Magic Gem of Contract (2)");
		SetDescription("Activate the Magic Field of Preservation at the Shrine of Remembrance");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CATACOMB_04_SQ_02_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(191));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_04_SQ_01"));
		AddPrerequisite(new ItemPrerequisite("CATACOMB_04_SQ_01_ITEM", -100));

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("Vis", 5921));

		AddDialogHook("CATACOMB_04_OBJ_02", "BeforeStart", BeforeStart);
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

		if (character.Inventory.HasItem("CATACOMB_04_SQ_02_ITEM", 1))
		{
			character.Inventory.RemoveItem("CATACOMB_04_SQ_02_ITEM", 1);
			ZoneServer.Instance.World.FindNPC("CATACOMB_04_OBJ_01")?.PlayEffectLocal(character.Connection, "F_lineup020_blue_mint", 1f, "BOT");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

