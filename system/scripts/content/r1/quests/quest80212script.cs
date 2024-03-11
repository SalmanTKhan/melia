//--- Melia Script -----------------------------------------------------------
// The Worth of a Flower (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Edward.
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

[QuestScript(80212)]
public class Quest80212Script : QuestScript
{
	protected override void Load()
	{
		SetId(80212);
		SetName("The Worth of a Flower (1)");
		SetDescription("Talk to Edward");

		AddPrerequisite(new LevelPrerequisite(155));
		AddPrerequisite(new CompletedPrerequisite("FARM49_2_SQ08"));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 4495));

		AddDialogHook("FARM493_SQ_07", "BeforeStart", BeforeStart);
		AddDialogHook("FARM493_SQ_07", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM49_3_SQ07_select_01", "FARM49_3_SQ07", "You don't look so good.", "I have nothing else to say."))
		{
			case 1:
				await dialog.Msg("FARM49_3_SQ07_agree_01");
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

		await dialog.Msg("FARM49_3_SQ07_succ_01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

