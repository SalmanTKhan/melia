//--- Melia Script -----------------------------------------------------------
// Returned Memories
//--- Description -----------------------------------------------------------
// Quest to Talk to Archivist Jonas.
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

[QuestScript(4435)]
public class Quest4435Script : QuestScript
{
	protected override void Load()
	{
		SetId(4435);
		SetName("Returned Memories");
		SetDescription("Talk to Archivist Jonas");

		AddPrerequisite(new LevelPrerequisite(58));
		AddPrerequisite(new CompletedPrerequisite("ROKAS24_QB_14"));

		AddObjective("kill0", "Kill 6 Geppetto(s) or Dandel(s) or Pino(s)", new KillObjective(6, 401101, 401401, 401181));

		AddReward(new ExpReward(42210, 42210));
		AddReward(new ItemReward("expCard3", 1));
		AddReward(new ItemReward("Drug_SP1_Q", 30));
		AddReward(new ItemReward("Vis", 1044));

		AddDialogHook("ROKAS_24_FLORIJONAS2", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS24_QB_8_select1", "ROKAS24_QB_8", "I will follow you", "My work is done so I'll be going now"))
		{
			case 1:
				await dialog.Msg("ROKAS24_QB_8_AC");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

