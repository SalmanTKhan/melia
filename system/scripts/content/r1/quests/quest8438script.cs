//--- Melia Script -----------------------------------------------------------
// Prevent the Corruption
//--- Description -----------------------------------------------------------
// Quest to Talk to the Guardian Stone Statue.
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

[QuestScript(8438)]
public class Quest8438Script : QuestScript
{
	protected override void Load()
	{
		SetId(8438);
		SetName("Prevent the Corruption");
		SetDescription("Talk to the Guardian Stone Statue");

		AddPrerequisite(new LevelPrerequisite(87));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 1740));

		AddDialogHook("ZACHA3F_MQ", "BeforeStart", BeforeStart);
		AddDialogHook("ZACHA3F_MQ", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ZACHA3F_SQ_01_01", "ZACHA3F_SQ_01", "Find the corrupted cores and remove it", "Decline"))
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

		await dialog.Msg("ZACHA3F_SQ_01_03");
		await Task.Delay(5000);
		dialog.HideNPC("ZACHA3F_SQ_01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

