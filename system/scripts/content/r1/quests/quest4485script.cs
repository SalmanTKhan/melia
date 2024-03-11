//--- Melia Script -----------------------------------------------------------
// Circulation Purifier Issues (3)
//--- Description -----------------------------------------------------------
// Quest to Inspect the Purifier Pipe in District 2.
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

[QuestScript(4485)]
public class Quest4485Script : QuestScript
{
	protected override void Load()
	{
		SetId(4485);
		SetName("Circulation Purifier Issues (3)");
		SetDescription("Inspect the Purifier Pipe in District 2");

		AddPrerequisite(new LevelPrerequisite(19));
		AddPrerequisite(new CompletedPrerequisite("MINE_2_CRYSTAL_3"));

		AddReward(new ExpReward(10744, 10744));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 7));
		AddReward(new ItemReward("Vis", 247));

		AddDialogHook("MINE_2_PURIFY_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "The Circulation Purifier is working again!");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnStart(Character character, Quest quest)
	{
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You have defeated the Carapace interrupting you{nl}Inspect the Purifier at District 2");
	}
}

