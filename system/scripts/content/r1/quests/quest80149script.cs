//--- Melia Script -----------------------------------------------------------
// Before It's Too Late (1)
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

[QuestScript(80149)]
public class Quest80149Script : QuestScript
{
	protected override void Load()
	{
		SetId(80149);
		SetName("Before It's Too Late (1)");
		SetDescription("Talk to Kupole Serija");

		AddPrerequisite(new LevelPrerequisite(298));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_3_MQ_10"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 12516));

		AddDialogHook("LIMESTONECAVE_52_4_SERIJA", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONECAVE_52_4_MEDENA_AI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_4_MQ_1_start", "LIMESTONE_52_4_MQ_1", "It's okay, I'll find Goddess Dalia.", "I don't think I can find traces of the goddess."))
		{
			case 1:
				// Func/LIMESTONE_52_4_REENTER_RUN;
				await dialog.Msg("LIMESTONE_52_4_MQ_1_AG");
				// Func/LIMESTONE_52_4_MQ_1_ST_1;
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

		await dialog.Msg("LIMESTONE_52_4_MQ_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

