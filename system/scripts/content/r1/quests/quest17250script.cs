//--- Melia Script -----------------------------------------------------------
// Purifying Doll (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Watcher Molly.
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

[QuestScript(17250)]
public class Quest17250Script : QuestScript
{
	protected override void Load()
	{
		SetId(17250);
		SetName("Purifying Doll (1)");
		SetDescription("Talk to Watcher Molly");

		AddPrerequisite(new LevelPrerequisite(29));
		AddPrerequisite(new CompletedPrerequisite("GELE572_MQ_05"));

		AddReward(new ExpReward(26860, 26860));
		AddReward(new ItemReward("expCard2", 2));
		AddReward(new ItemReward("Vis", 406));

		AddDialogHook("GELE572_NPC_MORI", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("GELE572_MQ_06_ST", "GELE572_MQ_06", "Alright", "About the corrupted land with evil energy", "Decline"))
		{
			case 1:
				await dialog.Msg("GELE572_MQ_06_AG");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("GELE572_MQ_06_ST_add");
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("GELE572_MQ_07");
	}
}

