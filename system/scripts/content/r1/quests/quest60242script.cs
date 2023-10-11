//--- Melia Script -----------------------------------------------------------
// Change of Focus
//--- Description -----------------------------------------------------------
// Quest to Talk to Neringa.
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

[QuestScript(60242)]
public class Quest60242Script : QuestScript
{
	protected override void Load()
	{
		SetId(60242);
		SetName("Change of Focus");
		SetDescription("Talk to Neringa");

		AddPrerequisite(new LevelPrerequisite(335));
		AddPrerequisite(new CompletedPrerequisite("FANTASYLIB481_MQ_PRE_2"));

		AddObjective("kill0", "Kill 20 Page Mimic(s) or Bookmark Mimic(s) or Oscuro(s) or Claro(s)", new KillObjective(20, 58867, 58866, 58864, 58865));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("FLIBRARY481_NERINGA_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("FLIBRARY481_NERINGA_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FANTASYLIB481_MQ_1_1", "FANTASYLIB481_MQ_1", "I'll follow the plan", "I'll wait a little bit"))
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

		await dialog.Msg("FANTASYLIB481_MQ_1_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

