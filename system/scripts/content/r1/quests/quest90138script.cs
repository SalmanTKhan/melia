//--- Melia Script -----------------------------------------------------------
// Clean Up the Demons
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

[QuestScript(90138)]
public class Quest90138Script : QuestScript
{
	protected override void Load()
	{
		SetId(90138);
		SetName("Clean Up the Demons");
		SetDescription("Talk with Kupole Leda");

		AddPrerequisite(new LevelPrerequisite(292));
		AddPrerequisite(new CompletedPrerequisite("F_DCAPITAL_20_5_SQ_90"));
		AddPrerequisite(new ItemPrerequisite("F_DCAPITAL_20_5_SQ_60_ITEM", -100));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 12264));

		AddDialogHook("DCAPITAL_20_5_REDA", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL_20_5_REDA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_DCAPITAL_20_5_SQ_100_ST", "F_DCAPITAL_20_5_SQ_100", "I'll be right back.", "Don't feel like it"))
		{
			case 1:
				await dialog.Msg("F_DCAPITAL_20_5_SQ_100_AG");
				dialog.UnHideNPC("DCAPITAL_20_5_SQ_100");
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

		await dialog.Msg("F_DCAPITAL_20_5_SQ_100_SU");
		dialog.HideNPC("DCAPITAL_20_5_SQ_100");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

