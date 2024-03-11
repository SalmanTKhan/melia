//--- Melia Script -----------------------------------------------------------
// It's the Honey (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Villager Darren.
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

[QuestScript(16000)]
public class Quest16000Script : QuestScript
{
	protected override void Load()
	{
		SetId(16000);
		SetName("It's the Honey (1)");
		SetDescription("Talk to Villager Darren");

		AddPrerequisite(new LevelPrerequisite(160));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 4800));

		AddDialogHook("SIAULIAI_46_4_MQ01_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_46_4_MQ01_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_46_4_MQ_01_select", "SIAULIAI_46_4_MQ_01", "I'll check it out", "About the town", "I'm busy so I'll pass"))
		{
			case 1:
				await dialog.Msg("SIAULIAI_46_4_MQ_01_start_prog");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("SIAULIAI_46_4_MQ_01_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("SIAULIAI_46_4_MQ_01_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("SIAULIAI_46_4_MQ_02");
	}
}

