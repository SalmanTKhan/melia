//--- Melia Script -----------------------------------------------------------
// The Fury
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Zydrone.
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

[QuestScript(60033)]
public class Quest60033Script : QuestScript
{
	protected override void Load()
	{
		SetId(60033);
		SetName("The Fury");
		SetDescription("Talk to Kupole Zydrone");

		AddPrerequisite(new LevelPrerequisite(157));
		AddPrerequisite(new CompletedPrerequisite("VPRISON514_MQ_06"));

		AddObjective("kill0", "Kill 10 Elma(s) or Nuo(s) or Socket(s) or Big Green Griba(s)", new KillObjective(10, 57691, 57689, 57449, 400463));

		AddReward(new ExpReward(852900, 852900));
		AddReward(new ItemReward("expCard8", 4));
		AddReward(new ItemReward("Vis", 4553));

		AddDialogHook("VPRISON514_MQ_ZYDRONE", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON514_MQ_ZYDRONE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("VPRISON514_SQ_01_01", "VPRISON514_SQ_01", "I will defeat the demons", "I don't have time for that"))
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

		await dialog.Msg("VPRISON514_SQ_01_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

