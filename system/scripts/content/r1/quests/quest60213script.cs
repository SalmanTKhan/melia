//--- Melia Script -----------------------------------------------------------
// Alembique Tales(4)
//--- Description -----------------------------------------------------------
// Quest to Find Traces of Mercenary Heranda.
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

[QuestScript(60213)]
public class Quest60213Script : QuestScript
{
	protected override void Load()
	{
		SetId(60213);
		SetName("Alembique Tales(4)");
		SetDescription("Find Traces of Mercenary Heranda");

		AddPrerequisite(new LevelPrerequisite(320));
		AddPrerequisite(new CompletedPrerequisite("LSCAVE551_SQ_3"));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15040));

		AddDialogHook("LSCAVE551_CELVERKA_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("LSCAVE551_SQ_4_3");
		dialog.HideNPC("LSCAVE551_SQ_4_OBJ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

