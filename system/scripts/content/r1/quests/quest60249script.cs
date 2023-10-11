//--- Melia Script -----------------------------------------------------------
// Going Below the Shadow (2)
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

[QuestScript(60249)]
public class Quest60249Script : QuestScript
{
	protected override void Load()
	{
		SetId(60249);
		SetName("Going Below the Shadow (2)");
		SetDescription("Talk to Neringa");

		AddPrerequisite(new LevelPrerequisite(338));
		AddPrerequisite(new CompletedPrerequisite("FANTASYLIB482_MQ_1"));

		AddObjective("kill0", "Kill 20 Levada(s) or Martybook(s) or Archless Angel(s) or Luna Angel(s)", new KillObjective(20, 58870, 58871, 58868, 58869));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("FLIBRARY482_NERINGA_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("FLIBRARY482_SVAJA_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FANTASYLIB482_MQ_2_1", "FANTASYLIB482_MQ_2", "I will defeat it", "I will prepare a little more"))
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

		await dialog.Msg("FANTASYLIB482_MQ_2_3");
		dialog.HideNPC("FLIBRARY482_NERINGA_NPC_1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

