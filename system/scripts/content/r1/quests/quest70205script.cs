//--- Melia Script -----------------------------------------------------------
// Protect the Camp
//--- Description -----------------------------------------------------------
// Quest to Talk to Baskez.
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

[QuestScript(70205)]
public class Quest70205Script : QuestScript
{
	protected override void Load()
	{
		SetId(70205);
		SetName("Protect the Camp");
		SetDescription("Talk to Baskez");

		AddPrerequisite(new LevelPrerequisite(212));

		AddObjective("kill0", "Kill 15 Green Lepusbunny(s) or Red Saltisdaughter Magician(s)", new KillObjective(15, 57889, 57938));

		AddReward(new ExpReward(1082046, 1082046));
		AddReward(new ItemReward("expCard11", 4));
		AddReward(new ItemReward("Vis", 7420));

		AddDialogHook("TABLELAND281_SQ_06", "BeforeStart", BeforeStart);
		AddDialogHook("TABLELAND281_SQ_06", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND28_1_SQ_06_1", "TABLELAND28_1_SQ06", "I will take care of those monsters", "I don't have time for that"))
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

		await dialog.Msg("TABLELAND28_1_SQ_06_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

