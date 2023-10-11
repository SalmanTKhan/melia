//--- Melia Script -----------------------------------------------------------
// Dislike for Danger
//--- Description -----------------------------------------------------------
// Quest to Talk to Kirina.
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

[QuestScript(16120)]
public class Quest16120Script : QuestScript
{
	protected override void Load()
	{
		SetId(16120);
		SetName("Dislike for Danger");
		SetDescription("Talk to Kirina");

		AddPrerequisite(new LevelPrerequisite(160));

		AddObjective("kill0", "Kill 20 Rabbee(s) or Honeybean(s)", new KillObjective(20, 57447, 57450));

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 4800));

		AddDialogHook("SIAULIAI_46_4_SQ03_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_46_4_SQ03_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_46_4_SQ_03_select", "SIAULIAI_46_4_SQ_03", "I'll take care of the monsters around", "Be careful and don't let your guard down on your way back"))
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

		await dialog.Msg("SIAULIAI_46_4_SQ_03_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

