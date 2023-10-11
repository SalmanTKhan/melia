//--- Melia Script -----------------------------------------------------------
// Lost Star
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Aldona.
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

[QuestScript(60035)]
public class Quest60035Script : QuestScript
{
	protected override void Load()
	{
		SetId(60035);
		SetName("Lost Star");
		SetDescription("Talk to Kupole Aldona");

		AddPrerequisite(new LevelPrerequisite(157));
		AddPrerequisite(new CompletedPrerequisite("VPRISON514_MQ_06"));

		AddReward(new ExpReward(852900, 852900));
		AddReward(new ItemReward("expCard8", 4));
		AddReward(new ItemReward("Vis", 4553));

		AddDialogHook("VPRISON514_MQ_ALDONA", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON514_MQ_ALDONA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("VPRISON514_SQ_03_01", "VPRISON514_SQ_03", "I will collect the Marks of Star", "I don't have for that"))
		{
			case 1:
				dialog.UnHideNPC("VPRISON514_SQ_03_NPC");
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

		await dialog.Msg("VPRISON514_SQ_03_03");
		dialog.HideNPC("VPRISON514_SQ_03_NPC");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

