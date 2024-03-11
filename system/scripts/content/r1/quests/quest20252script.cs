//--- Melia Script -----------------------------------------------------------
// Fight Poison with Poison (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Believer Adele.
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

[QuestScript(20252)]
public class Quest20252Script : QuestScript
{
	protected override void Load()
	{
		SetId(20252);
		SetName("Fight Poison with Poison (3)");
		SetDescription("Talk to Believer Adele");

		AddPrerequisite(new LevelPrerequisite(58));
		AddPrerequisite(new CompletedPrerequisite("THORN19_MQ07"));

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1044));

		AddDialogHook("THORN19_BELIEVER02", "BeforeStart", BeforeStart);
		AddDialogHook("THORN19_BELIEVER02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN19_MQ08_select01", "THORN19_MQ08", "I'll combine it", "About the Thorn Forest in the past", "I'm busy"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("THORN19_MQ08_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("THORN19_MQ08_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

