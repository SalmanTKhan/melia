//--- Melia Script -----------------------------------------------------------
// Wandering Believer's Soul
//--- Description -----------------------------------------------------------
// Quest to Talk to the Wandering Spirit of a Believer.
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

[QuestScript(60173)]
public class Quest60173Script : QuestScript
{
	protected override void Load()
	{
		SetId(60173);
		SetName("Wandering Believer's Soul");
		SetDescription("Talk to the Wandering Spirit of a Believer");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 12 Black Apparition(s) or (s) or Green Slime(s) or Green Stoulet(s) or Colitile(s)", new KillObjective(12, 58112, 20026, 58102, 58114, 58108));

		AddReward(new ExpReward(24571, 24571));
		AddReward(new ItemReward("expCard5", 1));
		AddReward(new ItemReward("Vis", 1406));

		AddDialogHook("CATACOMB332_RP_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB332_RP_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATACOMB332_RP_1_1", "CATACOMB332_RP_1", "Alright", "Decline"))
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


		return HookResult.Break;
	}
}

