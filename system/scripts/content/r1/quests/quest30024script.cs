//--- Melia Script -----------------------------------------------------------
// Inseparable Spirit
//--- Description -----------------------------------------------------------
// Quest to Talk to Jane's Spirit.
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

[QuestScript(30024)]
public class Quest30024Script : QuestScript
{
	protected override void Load()
	{
		SetId(30024);
		SetName("Inseparable Spirit");
		SetDescription("Talk to Jane's Spirit");

		AddPrerequisite(new LevelPrerequisite(197));

		AddReward(new ExpReward(237943, 237943));
		AddReward(new ItemReward("expCard10", 3));
		AddReward(new ItemReward("Vis", 6107));

		AddDialogHook("CATACOMB_02_NPC_01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATACOMB_02_SQ_01_select", "CATACOMB_02_SQ_01", "Go ahead, tell me the story", "I don't have time for that"))
		{
			case 1:
				await dialog.Msg("CATACOMB_02_SQ_01_agree");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

