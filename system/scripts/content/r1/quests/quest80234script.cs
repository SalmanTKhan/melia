//--- Melia Script -----------------------------------------------------------
// Demons on the Move
//--- Description -----------------------------------------------------------
// Quest to Find the Hunting Grounds.
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

[QuestScript(80234)]
public class Quest80234Script : QuestScript
{
	protected override void Load()
	{
		SetId(80234);
		SetName("Demons on the Move");
		SetDescription("Find the Hunting Grounds");

		AddPrerequisite(new LevelPrerequisite(150));

		AddReward(new ExpReward(710750, 710750));
		AddReward(new ItemReward("expCard8", 1));
		AddReward(new ItemReward("Vis", 4350));

		AddDialogHook("FREE_DUNGEON_SIGN1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("TUTO_FREE_DUNGEON_SIGN1");
		dialog.ShowHelp("TUTO_FREE_DUNGEON");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnStart(Character character, Quest quest)
	{
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You can now use Hunting Grounds!{nl}Press the F5 key to read the details in the Quest info window!");
	}
}

