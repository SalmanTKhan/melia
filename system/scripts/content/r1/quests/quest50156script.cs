//--- Melia Script -----------------------------------------------------------
// Remaining Demon Forces
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

[QuestScript(50156)]
public class Quest50156Script : QuestScript
{
	protected override void Load()
	{
		SetId(50156);
		SetName("Remaining Demon Forces");
		SetDescription("Talk to Assistant Commander Talon");

		AddPrerequisite(new LevelPrerequisite(238));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_70_SQ9"));

		AddObjective("kill0", "Kill 12 Blue Cronewt(s) or Blue Hohen Mage(s) or Blue Hohen Mane(s) or Blue Lapasape Shaman(s)", new KillObjective(12, 57953, 57973, 57967, 57945));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 1));
		AddReward(new ItemReward("Vis", 8568));

		AddDialogHook("TABLE70_CAPTIN1_3", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE70_CAPTIN1_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_70_SQ11_startnpc01", "TABLELAND_70_SQ11", "I'll defeat the demon remnants", "Everything will be alright"))
		{
			case 1:
				await dialog.Msg("TABLELAND_70_SQ11_AG");
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

		await dialog.Msg("TABLELAND_70_SQ11_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

