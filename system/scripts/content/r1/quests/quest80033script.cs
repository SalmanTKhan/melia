//--- Melia Script -----------------------------------------------------------
// The Missing Girl (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Druid Leja.
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

[QuestScript(80033)]
public class Quest80033Script : QuestScript
{
	protected override void Load()
	{
		SetId(80033);
		SetName("The Missing Girl (3)");
		SetDescription("Talk to Druid Leja");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_342_MQ_04"));

		AddDialogHook("ORCHARD342_LEJA", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORCHARD_342_MQ_05_start", "ORCHARD_342_MQ_05", "I'll do it right away", "I need some time to prepare"))
		{
			case 1:
				await dialog.Msg("ORCHARD_342_MQ_05_start_agree");
				dialog.UnHideNPC("ORCHARD42_BINDIG_GIRL");
				await dialog.Msg("NPCAin/npc_druid_leja/std/0");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ORCHARD_342_MQ_06");
	}
}

