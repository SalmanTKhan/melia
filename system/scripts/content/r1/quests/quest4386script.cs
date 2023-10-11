//--- Melia Script -----------------------------------------------------------
// Owl Sculpture's Little Help
//--- Description -----------------------------------------------------------
// Quest to Talk to the Substitute Owl Sculpture.
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

[QuestScript(4386)]
public class Quest4386Script : QuestScript
{
	protected override void Load()
	{
		SetId(4386);
		SetName("Owl Sculpture's Little Help");
		SetDescription("Talk to the Substitute Owl Sculpture");

		AddPrerequisite(new LevelPrerequisite(121));

		AddObjective("kill0", "Kill 13 Treegool(s)", new KillObjective(13, MonsterId.TreeGool));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3025));

		AddDialogHook("THORN22_OWL1", "BeforeStart", BeforeStart);
		AddDialogHook("THORN22_OWL1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN22_Q_15_select1", "THORN22_Q_15", "I'll get rid of them for you", "Decline"))
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

		await dialog.Msg("THORN22_Q_15_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

