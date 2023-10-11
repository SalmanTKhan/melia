//--- Melia Script -----------------------------------------------------------
// To the Path of Eternal Rest
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Roana.
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

[QuestScript(80207)]
public class Quest80207Script : QuestScript
{
	protected override void Load()
	{
		SetId(80207);
		SetName("To the Path of Eternal Rest");
		SetDescription("Talk to Priest Roana");

		AddPrerequisite(new LevelPrerequisite(144));
		AddPrerequisite(new CompletedPrerequisite("PILGRIMROAD55_SQ05"));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 3744));

		AddDialogHook("PILGRIMROAD55_SQ05", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIMROAD55_SQ05", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIMROAD55_SQ12_select01", "PILGRIMROAD55_SQ12", "I can help.", "I have no time to help, sorry."))
		{
			case 1:
				await dialog.Msg("PILGRIMROAD55_SQ12_agree01");
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

		await dialog.Msg("PILGRIMROAD55_SQ12_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

