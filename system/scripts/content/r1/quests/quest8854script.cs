//--- Melia Script -----------------------------------------------------------
// Lab Destroyer
//--- Description -----------------------------------------------------------
// Quest to Talk with Alchemist Saliamonas.
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

[QuestScript(8854)]
public class Quest8854Script : QuestScript
{
	protected override void Load()
	{
		SetId(8854);
		SetName("Lab Destroyer");
		SetDescription("Talk with Alchemist Saliamonas");

		AddPrerequisite(new LevelPrerequisite(196));

		AddObjective("kill0", "Kill 3 Rubabos(s)", new KillObjective(3, MonsterId.Rubabos));

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("Vis", 6076));

		AddDialogHook("FLASH64_SALIAMONS", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH64_SALIAMONS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH64_SQ_10_01", "FLASH64_SQ_10", "I will defeat it", "Decline"))
		{
			case 1:
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

		await dialog.Msg("FLASH64_SQ_10_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

