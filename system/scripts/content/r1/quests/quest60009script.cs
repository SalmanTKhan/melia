//--- Melia Script -----------------------------------------------------------
// Ridding the Traitor (3)
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

[QuestScript(60009)]
public class Quest60009Script : QuestScript
{
	protected override void Load()
	{
		SetId(60009);
		SetName("Ridding the Traitor (3)");
		SetDescription("Talk to Kupole Arune");

		AddPrerequisite(new LevelPrerequisite(154));
		AddPrerequisite(new CompletedPrerequisite("VPRISON512_MQ_02"));

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

		switch (await dialog.Select("VPRISON512_MQ_03_01", "VPRISON512_MQ_03", "I'll help you", "Everything will be alright"))
		{
			case 1:
				await dialog.Msg("VPRISON512_MQ_03_AG");
				// Func/VPRISON512_MQ_03_HAUBERK_01;
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

		await dialog.Msg("VPRISON512_MQ_03_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

