//--- Melia Script -----------------------------------------------------------
// Fight Poison with Poison (4)
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

[QuestScript(20253)]
public class Quest20253Script : QuestScript
{
	protected override void Load()
	{
		SetId(20253);
		SetName("Fight Poison with Poison (4)");
		SetDescription("Talk to Believer Adele");

		AddPrerequisite(new LevelPrerequisite(58));
		AddPrerequisite(new CompletedPrerequisite("THORN19_MQ08"));

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1044));

		AddDialogHook("THORN19_BELIEVER02", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN19_MQ09_select01", "THORN19_MQ09", "I'll melt the thorny vines", "I can only help so much"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

