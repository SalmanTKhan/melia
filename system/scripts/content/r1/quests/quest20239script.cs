//--- Melia Script -----------------------------------------------------------
// The Final Mission (3)
//--- Description -----------------------------------------------------------
// Quest to Carry out Operation Tree Dale.
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

[QuestScript(20239)]
public class Quest20239Script : QuestScript
{
	protected override void Load()
	{
		SetId(20239);
		SetName("The Final Mission (3)");
		SetDescription("Carry out Operation Tree Dale");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "REMAIN39_SQ03_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(103));
		AddPrerequisite(new CompletedPrerequisite("REMAIN39_SQ02"));

		AddObjective("collect0", "Collect 1 Unicorn Horn", new CollectItemObjective("REMAIN39_SQ03_ITEM", 1));
		AddDrop("REMAIN39_SQ03_ITEM", 10f, "boss_unicorn_Q1");

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("misc_liena_pants_1", 1));
		AddReward(new ItemReward("Vis", 2472));

		AddDialogHook("REMAINS39_GHOST_BAG_2", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS39_GHOST", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("Func/REMAIN39_SQ03_BAL_1", "REMAIN39_SQ03", "Carry out the Tree Dale plan", "Need more preparations"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("REMAIN39_SQ03_ITEM", 1))
		{
			character.Inventory.RemoveItem("REMAIN39_SQ03_ITEM", 1);
			// Func/REMAIN39_SQ03_BAL;
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("REMAIN39_SQ04");
	}
}

