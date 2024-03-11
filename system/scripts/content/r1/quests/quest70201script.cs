//--- Melia Script -----------------------------------------------------------
// To the Camp
//--- Description -----------------------------------------------------------
// Quest to Talk with Higgs.
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

[QuestScript(70201)]
public class Quest70201Script : QuestScript
{
	protected override void Load()
	{
		SetId(70201);
		SetName("To the Camp");
		SetDescription("Talk with Higgs");

		AddPrerequisite(new LevelPrerequisite(212));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND28_1_SQ01"));

		AddReward(new ExpReward(1082046, 1082046));
		AddReward(new ItemReward("expCard11", 4));
		AddReward(new ItemReward("Vis", 7420));

		AddDialogHook("TABLELAND281_SQ_02", "BeforeStart", BeforeStart);
		AddDialogHook("TABLELAND281_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND28_1_SQ_02_1", "TABLELAND28_1_SQ02", "Follow me well", "I need to prepare"))
		{
			case 1:
				// Func/SCR_TABLELAND281_SQ_02_S;
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

		await dialog.Msg("TABLELAND28_1_SQ_02_2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

