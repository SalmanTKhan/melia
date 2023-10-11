//--- Melia Script -----------------------------------------------------------
// The Hidden Betrayer
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Daiva.
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

[QuestScript(60037)]
public class Quest60037Script : QuestScript
{
	protected override void Load()
	{
		SetId(60037);
		SetName("The Hidden Betrayer");
		SetDescription("Talk to Kupole Daiva");

		AddPrerequisite(new LevelPrerequisite(160));
		AddPrerequisite(new CompletedPrerequisite("VPRISON513_SQ_01"));

		AddObjective("kill0", "Kill 10 Hohen Ritter(s) or Hohen Barkle(s) or Hohen Orben(s) or Hohen Mane(s)", new KillObjective(10, 57716, 57717, 57719, 57715));

		AddReward(new ExpReward(1256004, 1256004));
		AddReward(new ItemReward("expCard9", 4));
		AddReward(new ItemReward("Vis", 4800));

		AddDialogHook("VPRISON513_MQ_DAIVA_03", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON513_MQ_DAIVA_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("VPRISON513_SQ_02_01", "VPRISON513_SQ_02", "I will defeat it", "Tell her that there is a more emergent issue"))
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

		await dialog.Msg("VPRISON513_SQ_02_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

