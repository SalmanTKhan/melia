//--- Melia Script -----------------------------------------------------------
// The Goddess' Sacrifice (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Medena.
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

[QuestScript(80171)]
public class Quest80171Script : QuestScript
{
	protected override void Load()
	{
		SetId(80171);
		SetName("The Goddess' Sacrifice (2)");
		SetDescription("Talk to Kupole Medena");

		AddPrerequisite(new LevelPrerequisite(301));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_5_MQ_9"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 104));
		AddReward(new ItemReward("Vis", 152306));

		AddDialogHook("LIMESTONECAVE_52_5_MEDENA_2", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONECAVE_52_5_MEDENA_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_5_MQ_10_start", "LIMESTONE_52_5_MQ_10", "Be strong.", "I'll wait until you've calmed down."))
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

		await dialog.Msg("LIMESTONE_52_5_MQ_10_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

