//--- Melia Script -----------------------------------------------------------
// The Goddess' Assignment (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Mysterious Girl.
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

[QuestScript(80035)]
public class Quest80035Script : QuestScript
{
	protected override void Load()
	{
		SetId(80035);
		SetName("The Goddess' Assignment (2)");
		SetDescription("Talk to the Mysterious Girl");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_342_MQ_06"));

		AddDialogHook("ORCHARD342_GIRL", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORCHARD_342_MQ_07_start", "ORCHARD_342_MQ_07", "Let's have a look at the girl's sapling", "Let's wait and see what happens"))
		{
			case 1:
				await Task.Delay(1000);
				dialog.HideNPC("ORCHARD342_GIRL");
				// Func/ORCHARD342_GIRL_DISAPPEAR;
				// Func/ORCHARD342_GIRL_DISAPPEAR_TXT;
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ORCHARD_342_MQ_08");
	}
}

