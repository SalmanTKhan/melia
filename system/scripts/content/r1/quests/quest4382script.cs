//--- Melia Script -----------------------------------------------------------
// Secure the Area
//--- Description -----------------------------------------------------------
// Quest to Talk to Soldier Poulter.
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

[QuestScript(4382)]
public class Quest4382Script : QuestScript
{
	protected override void Load()
	{
		SetId(4382);
		SetName("Secure the Area");
		SetDescription("Talk to Soldier Poulter");

		AddPrerequisite(new LevelPrerequisite(121));
		AddPrerequisite(new CompletedPrerequisite("THORN22_Q_10"));

		AddObjective("kill0", "Kill 15 Meleech(s) or Ravinelarva(s) or Wood Goblin(s) or Treegool(s)", new KillObjective(15, 41285, 41269, 41290, 41264));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3025));

		AddDialogHook("THORN22_POULLTER", "BeforeStart", BeforeStart);
		AddDialogHook("THORN22_POULLTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN22_Q_11_select1", "THORN22_Q_11", "Alright, I'll help you", "Decline"))
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

		await dialog.Msg("THORN22_Q_11_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

