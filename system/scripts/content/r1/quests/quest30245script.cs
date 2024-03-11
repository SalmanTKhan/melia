//--- Melia Script -----------------------------------------------------------
// Operation Outer Wall Core Retrieval (3)
//--- Description -----------------------------------------------------------
// Quest to Disarm the Primary Core Protection Device.
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

[QuestScript(30245)]
public class Quest30245Script : QuestScript
{
	protected override void Load()
	{
		SetId(30245);
		SetName("Operation Outer Wall Core Retrieval (3)");
		SetDescription("Disarm the Primary Core Protection Device");

		AddPrerequisite(new LevelPrerequisite(285));
		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_1_SQ_2"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11970));

		AddDialogHook("CASTLE_20_1_OBJ_4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		dialog.HideNPC("CASTLE_20_1_OBJ_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("CASTLE_20_1_SQ_4");
	}
}

