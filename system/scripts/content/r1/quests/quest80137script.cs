//--- Melia Script -----------------------------------------------------------
// Less Eyes to See
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Serija.
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

[QuestScript(80137)]
public class Quest80137Script : QuestScript
{
	protected override void Load()
	{
		SetId(80137);
		SetName("Less Eyes to See");
		SetDescription("Talk to Kupole Serija");

		AddPrerequisite(new LevelPrerequisite(294));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_2_MQ_9"));

		AddObjective("kill0", "Kill 16 Green Flamme(s) or Green Flamme Mage(s) or Green Bavon(s) or Green Rubblem(s) or Lakhtanon(s)", new KillObjective(16, 58469, 58470, 58467, 58468, 58438));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 12348));

		AddDialogHook("LIMESTONECAVE_52_3_SERIJA", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONECAVE_52_3_SERIJA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_3_MQ_1_start", "LIMESTONE_52_3_MQ_1", "Alright", "We don't have time for it"))
		{
			case 1:
				// Func/LIMESTONE_52_3_REENTER_RUN;
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

		await dialog.Msg("LIMESTONE_52_3_MQ_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

