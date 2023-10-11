//--- Melia Script -----------------------------------------------------------
// Lost and Found (1)
//--- Description -----------------------------------------------------------
// Quest to Find Merrisa.
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

[QuestScript(41640)]
public class Quest41640Script : QuestScript
{
	protected override void Load()
	{
		SetId(41640);
		SetName("Lost and Found (1)");
		SetDescription("Find Merrisa");

		AddPrerequisite(new LevelPrerequisite(110));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM_48_SQ_010"));

		AddObjective("kill0", "Kill 30 Lizardman(s)", new KillObjective(30, MonsterId.Sec_Lizardman));

		AddReward(new ExpReward(221139, 221139));
		AddReward(new ItemReward("expCard6", 5));
		AddReward(new ItemReward("Vis", 2640));

		AddDialogHook("PILGRIM_48_JURATE", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM_48_JURATE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM_48_SQ_040_ST", "PILGRIM_48_SQ_040", "I came here since Leopoldas asked me to help", "Ignore"))
		{
			case 1:
				await dialog.Msg("PILGRIM_48_SQ_040_AC");
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

		await dialog.Msg("PILGRIM_48_SQ_040_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

