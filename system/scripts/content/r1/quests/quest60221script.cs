//--- Melia Script -----------------------------------------------------------
// Alembique Tales(4)
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Celvica.
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

[QuestScript(60221)]
public class Quest60221Script : QuestScript
{
	protected override void Load()
	{
		SetId(60221);
		SetName("Alembique Tales(4)");
		SetDescription("Talk with Priest Celvica");

		AddPrerequisite(new LevelPrerequisite(320));
		AddPrerequisite(new CompletedPrerequisite("LSCAVE551_SQ_4"));

		AddObjective("kill0", "Kill 12 Cave Ravinelarva(s)", new KillObjective(12, MonsterId.RavineLerva_Cave));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15040));

		AddDialogHook("LSCAVE551_CELVERKA_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("LSCAVE551_CELVERKA_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LSCAVE551_SQ_5_1", "LSCAVE551_SQ_5", "I will try", "I don't think that's needed,"))
		{
			case 1:
				await dialog.Msg("LSCAVE551_SQ_5_1_1");
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

		await dialog.Msg("LSCAVE551_SQ_5_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

