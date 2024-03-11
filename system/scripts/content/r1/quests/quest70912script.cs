//--- Melia Script -----------------------------------------------------------
// Clean up while investigating
//--- Description -----------------------------------------------------------
// Quest to Talk to Investigator Horatio.
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

[QuestScript(70912)]
public class Quest70912Script : QuestScript
{
	protected override void Load()
	{
		SetId(70912);
		SetName("Clean up while investigating");
		SetDescription("Talk to Investigator Horatio");

		AddPrerequisite(new LevelPrerequisite(303));
		AddPrerequisite(new CompletedPrerequisite("DCAPITAL103_SQ11"), new CompletedPrerequisite("DCAPITAL103_SQ12"));

		AddReward(new ExpReward(12101740, 12101740));
		AddReward(new ItemReward("expCard13", 1));
		AddReward(new ItemReward("Vis", 13938));

		AddDialogHook("DCAPITAL103_SQ_11", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL103_SQ_11", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("DCAPITAL103_SQ_13_start", "DCAPITAL103_SQ13", "Leave it up to me.", "We should think it over."))
		{
			case 1:
				await dialog.Msg("DCAPITAL103_SQ_13_agree");
				await dialog.Msg("FadeOutIN/1000");
				dialog.HideNPC("DCAPITAL103_SQ_11");
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

		await dialog.Msg("DCAPITAL103_SQ_13_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

