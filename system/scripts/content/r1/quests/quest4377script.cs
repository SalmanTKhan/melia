//--- Melia Script -----------------------------------------------------------
// Soldier's Precious Belongings (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Soldier Samson.
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

[QuestScript(4377)]
public class Quest4377Script : QuestScript
{
	protected override void Load()
	{
		SetId(4377);
		SetName("Soldier's Precious Belongings (3)");
		SetDescription("Talk to Soldier Samson");

		AddPrerequisite(new LevelPrerequisite(120));
		AddPrerequisite(new CompletedPrerequisite("THORN22_Q_4"));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3000));

		AddDialogHook("THORN22_SAMSON", "BeforeStart", BeforeStart);
		AddDialogHook("THORN22_SAMSON", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN22_Q_6_select1", "THORN22_Q_6", "Leave it to me", "I'm busy"))
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

		await dialog.Msg("THORN22_Q_6_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

