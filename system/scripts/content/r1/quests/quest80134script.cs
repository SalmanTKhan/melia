//--- Melia Script -----------------------------------------------------------
// Where is the Goddess
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Serija.
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

[QuestScript(80134)]
public class Quest80134Script : QuestScript
{
	protected override void Load()
	{
		SetId(80134);
		SetName("Where is the Goddess");
		SetDescription("Talk to Kupole Serija");

		AddPrerequisite(new LevelPrerequisite(291));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_2_MQ_8"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));

		AddDialogHook("LIMESTONE_52_2_SERIJA", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONECAVE_52_3_SERIJA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_2_MQ_9_start", "LIMESTONE_52_2_MQ_9", "Alright", "I don't want to"))
		{
			case 1:
				// Func/LIMESTONE_52_2_REENTER_RUN;
				// Func/LIMESTONECAVE_HIDE_FUNC_RUN;
				dialog.HideNPC("LIMESTONE_52_2_SERIJA");
				dialog.UnHideNPC("LIMESTONECAVE_52_3_SERIJA");
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

		await dialog.Msg("LIMESTONE_52_2_MQ_9_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

