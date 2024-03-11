//--- Melia Script -----------------------------------------------------------
// Hometown Secret
//--- Description -----------------------------------------------------------
// Quest to Talk to Follower Wedge.
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

[QuestScript(70428)]
public class Quest70428Script : QuestScript
{
	protected override void Load()
	{
		SetId(70428);
		SetName("Hometown Secret");
		SetDescription("Talk to Follower Wedge");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("CASTLE65_2_MQ05"));

		AddObjective("collect0", "Collect 16 Charog Sap(s)", new CollectItemObjective("CASTLE65_2_SQ04_ITEM", 16));
		AddDrop("CASTLE65_2_SQ04_ITEM", 8f, "charog");

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("Vis", 1600));

		AddDialogHook("CASTLE652_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE652_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE652_SQ_04_start", "CASTLE65_2_SQ04", "I'll collect it", "I have more urgent issues to tend to"))
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


		return HookResult.Break;
	}
}

