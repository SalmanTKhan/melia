//--- Melia Script -----------------------------------------------------------
// Revitalized
//--- Description -----------------------------------------------------------
// Quest to Talk to Hunter Bastille.
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

[QuestScript(80216)]
public class Quest80216Script : QuestScript
{
	protected override void Load()
	{
		SetId(80216);
		SetName("Revitalized");
		SetDescription("Talk to Hunter Bastille");

		AddPrerequisite(new LevelPrerequisite(176));
		AddPrerequisite(new CompletedPrerequisite("THORN39_1_SQ01"));

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 5280));

		AddDialogHook("THORN391_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("THORN391_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN39_1_SQ04_slelect01", "THORN39_1_SQ04", "I'll get it", "Sorry, I'm allergic to honey."))
		{
			case 1:
				await dialog.Msg("THORN39_1_SQ04_agree01");
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

		await dialog.Msg("THORN39_1_SQ04_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

