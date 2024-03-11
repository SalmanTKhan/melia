//--- Melia Script -----------------------------------------------------------
// Astral Tracing (6)
//--- Description -----------------------------------------------------------
// Quest to Check the last gravestone.
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

[QuestScript(8752)]
public class Quest8752Script : QuestScript
{
	protected override void Load()
	{
		SetId(8752);
		SetName("Astral Tracing (6)");
		SetDescription("Check the last gravestone");

		AddPrerequisite(new LevelPrerequisite(99));
		AddPrerequisite(new CompletedPrerequisite("REMAIN38_MQ05"));

		AddReward(new ExpReward(122855, 122855));
		AddReward(new ItemReward("expCard6", 1));
		AddReward(new ItemReward("Vis", 1980));

		AddDialogHook("REMAIN38_MQ_MONUMENT5", "BeforeStart", BeforeStart);
		AddDialogHook("REMAIN38_MQ_MONUMENT5", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("REMAIN38_MQ06_03");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You are enlightened after checking what was written on the tombstones of Lydia Schaffen{nl}You have acquired 1 Status Point!");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

