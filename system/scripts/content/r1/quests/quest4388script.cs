//--- Melia Script -----------------------------------------------------------
// Off To A Journey
//--- Description -----------------------------------------------------------
// Quest to Talk to the Settled Owl Sculpture.
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

[QuestScript(4388)]
public class Quest4388Script : QuestScript
{
	protected override void Load()
	{
		SetId(4388);
		SetName("Off To A Journey");
		SetDescription("Talk to the Settled Owl Sculpture");

		AddPrerequisite(new LevelPrerequisite(121));
		AddPrerequisite(new CompletedPrerequisite("THORN22_Q_16"));

		AddObjective("kill0", "Kill 7 Ravinelarva(s)", new KillObjective(7, MonsterId.RavineLerva));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3025));

		AddDialogHook("THORN22_OWL2", "BeforeStart", BeforeStart);
		AddDialogHook("THORN22_OWL2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN22_Q_17_select1", "THORN22_Q_17", "I'll get rid of them for you", "Cancel"))
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

		await dialog.Msg("THORN22_Q_17_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

