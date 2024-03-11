//--- Melia Script -----------------------------------------------------------
// Ridding the Traitor (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Arune.
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

[QuestScript(60007)]
public class Quest60007Script : QuestScript
{
	protected override void Load()
	{
		SetId(60007);
		SetName("Ridding the Traitor (1)");
		SetDescription("Talk to Kupole Arune");

		AddPrerequisite(new LevelPrerequisite(154));
		AddPrerequisite(new CompletedPrerequisite("VPRISON511_MQ_05"));

		AddObjective("kill0", "Kill 10 Guardian Spider(s) or Nuka(s) or Elet(s)", new KillObjective(10, 57692, 57690, 57688));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 9));
		AddReward(new ItemReward("Vis", 4466));

		AddDialogHook("VPRISON512_MQ_NORGAILE", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON512_MQ_NORGAILE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("VPRISON512_MQ_01_01", "VPRISON512_MQ_01", "Tell me how I can help Aldona", "I need some time to prepare"))
		{
			case 1:
				await dialog.Msg("VPRISON512_MQ_01_AG");
				// Func/VPRISON512_MQ_01_HAUBERK_01;
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

		await dialog.Msg("VPRISON512_MQ_01_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

