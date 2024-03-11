//--- Melia Script -----------------------------------------------------------
// The Vulnerable Fugitive (5)
//--- Description -----------------------------------------------------------
// Quest to Rescue the Trapped Kupoles.
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

[QuestScript(60285)]
public class Quest60285Script : QuestScript
{
	protected override void Load()
	{
		SetId(60285);
		SetName("The Vulnerable Fugitive (5)");
		SetDescription("Rescue the Trapped Kupoles");

		AddPrerequisite(new LevelPrerequisite(371));
		AddPrerequisite(new CompletedPrerequisite("DCAPITAL105_SQ_4"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 19000));

		AddDialogHook("DCAPITAL105_GRISIA_NPC_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("DCAPITAL105_SQ_5_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.HideNPC("DCAPITAL105_GRISIA_NPC_1");
	}
}

