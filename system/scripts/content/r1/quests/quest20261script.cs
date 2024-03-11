//--- Melia Script -----------------------------------------------------------
// Some Help
//--- Description -----------------------------------------------------------
// Quest to Talk to Believer Alvydas.
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

[QuestScript(20261)]
public class Quest20261Script : QuestScript
{
	protected override void Load()
	{
		SetId(20261);
		SetName("Some Help");
		SetDescription("Talk to Believer Alvydas");

		AddPrerequisite(new LevelPrerequisite(61));

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1159));

		AddDialogHook("THORN20_MQ01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN20_MQ01_select01", "THORN20_MQ01", "I am the Revelator and I'll help you", "About the evil energy in the Thorn Forest", "Kvailas Forest is more urgent"))
		{
			case 1:
				await dialog.Msg("THORN20_MQ01_select02");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("THORN20_MQ01_add");
				break;
		}

		return HookResult.Break;
	}
}

