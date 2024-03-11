//--- Melia Script -----------------------------------------------------------
// Hungry Faith (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Elgos Monk.
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

[QuestScript(80091)]
public class Quest80091Script : QuestScript
{
	protected override void Load()
	{
		SetId(80091);
		SetName("Hungry Faith (2)");
		SetDescription("Talk to Elgos Monk");

		AddPrerequisite(new LevelPrerequisite(232));
		AddPrerequisite(new CompletedPrerequisite("ABBEY_35_4_SQ_2"));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 63));

		AddDialogHook("ABBEY_35_4_MONK", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY_35_4_ELDER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY_35_4_SQ_3_start", "ABBEY_35_4_SQ_3", "Ask what happened", "I will go now"))
		{
			case 1:
				await dialog.Msg("ABBEY_35_4_SQ_3_agree");
				dialog.UnHideNPC("ABBEY_35_4_ELDER");
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

		await dialog.Msg("ABBEY_35_4_SQ_3_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

