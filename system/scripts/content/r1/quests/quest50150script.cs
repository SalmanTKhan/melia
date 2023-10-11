//--- Melia Script -----------------------------------------------------------
// Preparing for Battle (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Assistant Commander Talon.
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

[QuestScript(50150)]
public class Quest50150Script : QuestScript
{
	protected override void Load()
	{
		SetId(50150);
		SetName("Preparing for Battle (2)");
		SetDescription("Talk to Assistant Commander Talon");

		AddPrerequisite(new LevelPrerequisite(238));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_70_SQ4"));

		AddObjective("kill0", "Kill 15 Blue Cronewt(s) or Blue Lapasape Shaman(s) or Blue Hohen Mane(s) or Blue Hohen Mage(s)", new KillObjective(15, 57953, 57945, 57967, 57973));

		AddReward(new ExpReward(5910366, 5910366));
		AddReward(new ItemReward("expCard12", 2));
		AddReward(new ItemReward("Vis", 8568));

		AddDialogHook("TABLE70_CAPTIN1_3", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE70_CAPTIN1_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_70_SQ5_startnpc01", "TABLELAND_70_SQ5", "I'll defeat the monsters", "Tell your soldiers to do it."))
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

		await dialog.Msg("TABLELAND_70_SQ5_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

