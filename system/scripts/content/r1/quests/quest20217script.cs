//--- Melia Script -----------------------------------------------------------
// Flurry's Epitaphs (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Villager.
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

[QuestScript(20217)]
public class Quest20217Script : QuestScript
{
	protected override void Load()
	{
		SetId(20217);
		SetName("Flurry's Epitaphs (4)");
		SetDescription("Talk to the Villager");

		AddPrerequisite(new LevelPrerequisite(103));
		AddPrerequisite(new CompletedPrerequisite("REMAINS39_MQ03"));

		AddReward(new ExpReward(122855, 122855));
		AddReward(new ItemReward("expCard6", 1));
		AddReward(new ItemReward("Vis", 2472));

		AddDialogHook("REMAINS39_PEAPLE", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS39_MQ_MONUMENT4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAINS39_MQ04_select01", "REMAINS39_MQ05", "Find the Epitaph", "I'll wait a little bit"))
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

		await dialog.Msg("REMAINS39_MQ05_succ01");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You've read a tombstone of Agailla Flurry{nl}Read the other tombstones to obtain the artifacts of Flurry");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

