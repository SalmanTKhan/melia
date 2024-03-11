//--- Melia Script -----------------------------------------------------------
// Playing with Fire! (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Believer Domas.
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

[QuestScript(20248)]
public class Quest20248Script : QuestScript
{
	protected override void Load()
	{
		SetId(20248);
		SetName("Playing with Fire! (3)");
		SetDescription("Talk to Believer Domas");

		AddPrerequisite(new LevelPrerequisite(58));
		AddPrerequisite(new CompletedPrerequisite("THORN19_MQ03"));

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1044));

		AddDialogHook("THORN19_BELIEVER", "BeforeStart", BeforeStart);
		AddDialogHook("THORN19_GATE01_OPEN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN19_MQ04_select01", "THORN19_MQ04", "I will burn the thorny vines", "You should take care of it from here"))
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

		await dialog.Msg("NPCAin/THORN_GATEWAY_1/OPEN1/1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

