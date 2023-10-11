//--- Melia Script -----------------------------------------------------------
// Can't Be Taken Away (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Zenius.
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

[QuestScript(19520)]
public class Quest19520Script : QuestScript
{
	protected override void Load()
	{
		SetId(19520);
		SetName("Can't Be Taken Away (1)");
		SetDescription("Talk to Pilgrim Zenius");

		AddPrerequisite(new LevelPrerequisite(121));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM46_SQ_089"));

		AddObjective("kill0", "Kill 16 Kepari(s) or Kepo(s) or Keposeed(s) or Beeteros(s) or Red Wood Goblin(s)", new KillObjective(16, 41449, 57404, 57402, 57024, 41291));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3025));

		AddDialogHook("PILGRIM46_NPC04", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM46_NPC04", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM46_SQ_090_ST", "PILGRIM46_SQ_090", "I want to help", "Leave since you don't wanna get involved"))
		{
			case 1:
				await dialog.Msg("PILGRIM46_SQ_090_AC");
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

		await dialog.Msg("PILGRIM46_SQ_090_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

