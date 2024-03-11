//--- Melia Script -----------------------------------------------------------
// Destroy the Demon Device(1)
//--- Description -----------------------------------------------------------
// Quest to Speak with Loremaster Ugnius.
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

[QuestScript(90212)]
public class Quest90212Script : QuestScript
{
	protected override void Load()
	{
		SetId(90212);
		SetName("Destroy the Demon Device(1)");
		SetDescription("Speak with Loremaster Ugnius");

		AddPrerequisite(new LevelPrerequisite(335));
		AddPrerequisite(new CompletedPrerequisite("CORAL_44_3_SQ_10"));

		AddObjective("kill0", "Kill 20 Varle Anchor(s) or Varle Henchmen(s) or Varle Skipper(s) or Varle Helmsman(s) or Nimrah Frieker(s)", new KillObjective(20, 58830, 58829, 58828, 58831, 58880));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));

		AddDialogHook("CORAL_44_3_OLDMAN1", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_44_3_KRUVINA1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_44_3_SQ_20_ST", "CORAL_44_3_SQ_20"))
		{
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		dialog.UnHideNPC("CORAL_44_3_OLDMAN2");
		await dialog.Msg("FadeOutIN/3000");
		dialog.HideNPC("CORAL_44_3_OLDMAN1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

