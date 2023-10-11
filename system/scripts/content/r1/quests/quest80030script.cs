//--- Melia Script -----------------------------------------------------------
// The Guiding Girl (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Druid Leja.
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

[QuestScript(80030)]
public class Quest80030Script : QuestScript
{
	protected override void Load()
	{
		SetId(80030);
		SetName("The Guiding Girl (2)");
		SetDescription("Talk to Druid Leja");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_342_MQ_01"));

		AddObjective("kill0", "Kill 6 Ferret(s) or Ferret Loader(s)", new KillObjective(6, 57850, 57851));

		AddDialogHook("ORCHARD342_LEJA", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORCHARD_342_MQ_02_start", "ORCHARD_342_MQ_02", "I'll go immediately", "I need to prepare"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ORCHARD_342_MQ_03");
	}
}

