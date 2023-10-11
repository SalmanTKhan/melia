//--- Melia Script -----------------------------------------------------------
// Depressed Spirit (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Bokor Master.
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

[QuestScript(50036)]
public class Quest50036Script : QuestScript
{
	protected override void Load()
	{
		SetId(50036);
		SetName("Depressed Spirit (1)");
		SetDescription("Talk to the Bokor Master");

		AddPrerequisite(new LevelPrerequisite(100));

		AddObjective("collect0", "Collect 53 Tini Essence(s)", new CollectItemObjective("PARTY_Q5_ITEM", 53));
		AddDrop("PARTY_Q5_ITEM", 10f, 57607, 57606);

		AddDialogHook("MASTER_BOCORS", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PARTY_Q_050_starnpc01", "PARTY_Q_050", "Sure, I'll help", "I don't have time for that"))
		{
			case 1:
				await dialog.Msg("PARTY_Q_050_starnpc02");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

