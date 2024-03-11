//--- Melia Script -----------------------------------------------------------
// To Make the Investigation Safe
//--- Description -----------------------------------------------------------
// Quest to Talk with Investigation Team Head Ella.
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

[QuestScript(70904)]
public class Quest70904Script : QuestScript
{
	protected override void Load()
	{
		SetId(70904);
		SetName("To Make the Investigation Safe");
		SetDescription("Talk with Investigation Team Head Ella");

		AddPrerequisite(new LevelPrerequisite(303));
		AddPrerequisite(new CompletedPrerequisite("DCAPITAL103_SQ04"));

		AddObjective("kill0", "Kill 18 Green Goblin Warrior(s) or Green Goblin Charger(s) or Green Goblin Wizard(s)", new KillObjective(18, 58493, 58494, 58495));

		AddReward(new ExpReward(12101740, 12101740));
		AddReward(new ItemReward("expCard13", 1));
		AddReward(new ItemReward("Vis", 13938));

		AddDialogHook("DCAPITAL103_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL103_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("DCAPITAL103_SQ_05_start", "DCAPITAL103_SQ05", "Say that it isn't too difficult", "I will patiently wait for the report."))
		{
			case 1:
				await dialog.Msg("DCAPITAL103_SQ_05_agree");
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

		await dialog.Msg("DCAPITAL103_SQ_05_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

