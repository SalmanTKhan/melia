//--- Melia Script -----------------------------------------------------------
// Half Honey, Half Monster
//--- Description -----------------------------------------------------------
// Quest to Talk to Ruined Bee Farmer Logen.
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

[QuestScript(16540)]
public class Quest16540Script : QuestScript
{
	protected override void Load()
	{
		SetId(16540);
		SetName("Half Honey, Half Monster");
		SetDescription("Talk to Ruined Bee Farmer Logen");

		AddPrerequisite(new LevelPrerequisite(166));

		AddObjective("kill0", "Kill 15 Big Black Griba(s) or Red Zigri(s) or Siaulamb Shaman(s) or Big Siaulamb(s)", new KillObjective(15, 57219, 400324, 57202, 57215));

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 4980));

		AddDialogHook("SIAULIAI_46_2_SQ_05_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_46_2_SQ_05_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_46_2_SQ_05_select", "SIAULIAI_46_2_SQ_05", "Comfort him", "Ignore it"))
		{
			case 1:
				await dialog.Msg("SIAULIAI_46_2_SQ_05_start_prog");
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

		await dialog.Msg("SIAULIAI_46_2_SQ_05_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

