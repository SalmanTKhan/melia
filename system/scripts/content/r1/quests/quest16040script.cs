//--- Melia Script -----------------------------------------------------------
// Sweet Revenge
//--- Description -----------------------------------------------------------
// Quest to Talk to Brewer Dorjen.
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

[QuestScript(16040)]
public class Quest16040Script : QuestScript
{
	protected override void Load()
	{
		SetId(16040);
		SetName("Sweet Revenge");
		SetDescription("Talk to Brewer Dorjen");

		AddPrerequisite(new LevelPrerequisite(160));
		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_46_4_MQ_04"));

		AddObjective("kill0", "Kill 6 Siaulamb Lagoon(s) or Pendinmire(s) or Orange Gribaru(s)", new KillObjective(6, 57203, 57217, 57423));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 38400));

		AddDialogHook("SIAULIAI_46_4_MQ04_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_46_4_MQ04_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_46_4_MQ_05_select", "SIAULIAI_46_4_MQ_05", "I'll defeat the monsters around, so lighten up dude.", "I've helped enough so I'm leaving"))
		{
			case 1:
				await dialog.Msg("SIAULIAI_46_4_MQ_05_start_prog");
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

		await dialog.Msg("SIAULIAI_46_4_MQ_05_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

