//--- Melia Script -----------------------------------------------------------
// Securing a Safe Route
//--- Description -----------------------------------------------------------
// Quest to Talk to Villager Emil.
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

[QuestScript(16730)]
public class Quest16730Script : QuestScript
{
	protected override void Load()
	{
		SetId(16730);
		SetName("Securing a Safe Route");
		SetDescription("Talk to Villager Emil");

		AddPrerequisite(new LevelPrerequisite(169));

		AddObjective("kill0", "Kill 20 Infro Blood(s) or Shardstatue(s) or Siaulav(s)", new KillObjective(20, 57044, 41258, 57208));

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 5070));

		AddDialogHook("SIAULIAI_46_1_SQ_04_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_46_1_SQ_04_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_46_1_SQ_04_select", "SIAULIAI_46_1_SQ_04", "I'll get rid of the monsters", "I'm busy"))
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

		await dialog.Msg("SIAULIAI_46_1_SQ_04_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

