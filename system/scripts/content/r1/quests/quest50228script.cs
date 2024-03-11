//--- Melia Script -----------------------------------------------------------
// Maven's Wishes(8)
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Lintas.
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

[QuestScript(50228)]
public class Quest50228Script : QuestScript
{
	protected override void Load()
	{
		SetId(50228);
		SetName("Maven's Wishes(8)");
		SetDescription("Talk to Priest Lintas");

		AddPrerequisite(new LevelPrerequisite(316));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_4_SQ6"));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14536));

		AddDialogHook("BRACKEN434_SUBQ1_NPC3", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN434_SUBQ1_NPC3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN43_4_SQ7_START1", "BRACKEN43_4_SQ7", "Agree to search the area", "Say that you will search a bit later"))
		{
			case 1:
				await dialog.Msg("BRACKEN43_4_SQ7_AGREE1");
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

		await dialog.Msg("BRACKEN43_4_SQ7_SUCC1");
		dialog.HideNPC("BRACKEN434_SUBQ1_NPC3");
		await dialog.Msg("FadeOutIN/1000");
		dialog.UnHideNPC("BRACKEN434_SUBQ_STELE_NPC3");
		dialog.HideNPC("BRACKEN434_SUBQ_FAKE_NPC3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

