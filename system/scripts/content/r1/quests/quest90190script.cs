//--- Melia Script -----------------------------------------------------------
// Followers of Goddess Jurate(3)
//--- Description -----------------------------------------------------------
// Quest to Speak with Revelator Pudhin.
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

[QuestScript(90190)]
public class Quest90190Script : QuestScript
{
	protected override void Load()
	{
		SetId(90190);
		SetName("Followers of Goddess Jurate(3)");
		SetDescription("Speak with Revelator Pudhin");

		AddPrerequisite(new LevelPrerequisite(327));
		AddPrerequisite(new CompletedPrerequisite("CORAL_44_1_SQ_20"));

		AddObjective("kill0", "Kill 15 Gob(s) or Varlefloater(s) or Aphisher(s) or Nimrah Damsel(s)", new KillObjective(15, 58821, 58823, 58820, 58822));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));

		AddDialogHook("CORAL_44_1_MAN1", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_44_1_OLDMAN1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_44_1_SQ_30_ST", "CORAL_44_1_SQ_30"))
		{
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("CORAL_44_1_SQ_30_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

