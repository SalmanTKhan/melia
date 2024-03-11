//--- Melia Script -----------------------------------------------------------
// Trace Race (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Kupole Leda.
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

[QuestScript(90151)]
public class Quest90151Script : QuestScript
{
	protected override void Load()
	{
		SetId(90151);
		SetName("Trace Race (1)");
		SetDescription("Talk with Kupole Leda");

		AddPrerequisite(new LevelPrerequisite(295));
		AddPrerequisite(new CompletedPrerequisite("F_DCAPITAL_20_6_SQ_20"));

		AddReward(new ExpReward(4840696, 4840696));
		AddReward(new ItemReward("expCard13", 4));
		AddReward(new ItemReward("Vis", 12390));

		AddDialogHook("DCAPITAL_20_6_REDA", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL_20_6_REDA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_DCAPITAL_20_6_SQ_25_ST", "F_DCAPITAL_20_6_SQ_25", "I will go and remove the magic circle.", "Tell him that it would be hard"))
		{
			case 1:
				await dialog.Msg("F_DCAPITAL_20_6_SQ_25_AG");
				dialog.UnHideNPC("DCAPITAL_20_6_SQ_25");
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

		await dialog.Msg("F_DCAPITAL_20_6_SQ_25_SU");
		dialog.HideNPC("DCAPITAL_20_6_SQ_25");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

