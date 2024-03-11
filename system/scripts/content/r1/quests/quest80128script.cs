//--- Melia Script -----------------------------------------------------------
// Another Kupole (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Alena.
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

[QuestScript(80128)]
public class Quest80128Script : QuestScript
{
	protected override void Load()
	{
		SetId(80128);
		SetName("Another Kupole (1)");
		SetDescription("Talk to Kupole Alena");

		AddPrerequisite(new LevelPrerequisite(291));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_2_MQ_2"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 12222));

		AddDialogHook("LIMESTONE_52_2_ALLENA", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONECAVE_52_2_MEDENA_AI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_2_MQ_3_start", "LIMESTONE_52_2_MQ_3", "Let's find Serija.", "Do as you wish now"))
		{
			case 1:
				// Func/LIMESTONE_52_2_REENTER_RUN;
				await dialog.Msg("LIMESTONE_52_2_MQ_3_agree");
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

		await dialog.Msg("LIMESTONE_52_2_MQ_3_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

