//--- Melia Script -----------------------------------------------------------
// Dangerous Encounter (2)
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

[QuestScript(80139)]
public class Quest80139Script : QuestScript
{
	protected override void Load()
	{
		SetId(80139);
		SetName("Dangerous Encounter (2)");
		SetDescription("Talk to Kupole Serija");

		AddPrerequisite(new LevelPrerequisite(294));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_3_MQ_2"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));

		AddDialogHook("LIMESTONECAVE_52_3_SERIJA", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONECAVE_52_3_SERIJA_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_3_MQ_3_start", "LIMESTONE_52_3_MQ_3", "Let's meet there.", "I don't know where."))
		{
			case 1:
				// Func/LIMESTONECAVE_HIDE_FUNC_RUN;
				// Func/LIMESTONE_52_3_REENTER_RUN;
				dialog.HideNPC("LIMESTONECAVE_52_3_SERIJA");
				dialog.UnHideNPC("LIMESTONECAVE_52_3_SERIJA_2");
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

		await dialog.Msg("LIMESTONE_52_3_MQ_3_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

