//--- Melia Script -----------------------------------------------------------
// Helping Hand
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

[QuestScript(80018)]
public class Quest80018Script : QuestScript
{
	protected override void Load()
	{
		SetId(80018);
		SetName("Helping Hand");
		SetDescription("Talk to Druid Leja");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(245710, 245710));
		AddReward(new ItemReward("expCard6", 2));
		AddReward(new ItemReward("Vis", 1840));

		AddDialogHook("ORCHARD323_LEJA", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORCHARD_323_MQ_01_start", "ORCHARD_323_MQ_01", "I'll go; what do the herbs look like?", "I'm busy"))
		{
			case 1:
				dialog.UnHideNPC("ORCHARD323_HERB");
				await dialog.Msg("ORCHARD_323_MQ_01_AG");
				// Func/ORCHARD_323_NPC_UNHIDE;
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ORCHARD_323_MQ_02");
	}
}

