//--- Melia Script -----------------------------------------------------------
// The Story Behind Them (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with the commander at Vedas Plateau.
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

[QuestScript(80063)]
public class Quest80063Script : QuestScript
{
	protected override void Load()
	{
		SetId(80063);
		SetName("The Story Behind Them (2)");
		SetDescription("Talk with the commander at Vedas Plateau");

		AddPrerequisite(new LevelPrerequisite(208));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_11_1_SQ_11"));

		AddReward(new ExpReward(541023, 541023));
		AddReward(new ItemReward("expCard11", 3));
		AddReward(new ItemReward("Vis", 7280));

		AddDialogHook("TABLELAND_11_1_SQ_03_LOCK", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH59_RETIA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_11_1_SQ_12_start", "TABLELAND_11_1_SQ_12", "I will pass it", "I can't hand it over"))
		{
			case 1:
				await dialog.Msg("TABLELAND_11_1_SQ_12_agree");
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

		await dialog.Msg("TABLELAND_11_1_SQ_12_succ");
		dialog.HideNPC("TABLELAND_11_1_FAUSTAS_DOWN2");
		dialog.HideNPC("TABLELAND_11_1_ELEMA");
		dialog.UnHideNPC("TABLELAND_11_1_RIP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

