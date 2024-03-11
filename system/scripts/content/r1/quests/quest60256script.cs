//--- Melia Script -----------------------------------------------------------
// Necessary Mistake (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Neringa.
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

[QuestScript(60256)]
public class Quest60256Script : QuestScript
{
	protected override void Load()
	{
		SetId(60256);
		SetName("Necessary Mistake (2)");
		SetDescription("Talk to Neringa");

		AddPrerequisite(new LevelPrerequisite(341));
		AddPrerequisite(new CompletedPrerequisite("FANTASYLIB483_MQ_1"));

		AddObjective("kill0", "Kill 20 Crowvasia(s) or Rotascion(s) or Boogey Box(s) or Gear(s)", new KillObjective(20, 58873, 58874, 58875, 58400));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("FLIBRARY483_NERINGA_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("FLIBRARY483_RYTE_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FANTASYLIB483_MQ_2_1", "FANTASYLIB483_MQ_2", "I'll take care of it", "I'll wait a little bit"))
		{
			case 1:
				await dialog.Msg("FadeOutIN/1500");
				dialog.HideNPC("FLIBRARY483_NERINGA_NPC_1");
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

		await dialog.Msg("FANTASYLIB483_MQ_2_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

