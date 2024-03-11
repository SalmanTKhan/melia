//--- Melia Script -----------------------------------------------------------
// Young Magician Owyn (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Young Magician Owyn.
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

[QuestScript(17002)]
public class Quest17002Script : QuestScript
{
	protected override void Load()
	{
		SetId(17002);
		SetName("Young Magician Owyn (1)");
		SetDescription("Talk to Young Magician Owyn");

		AddPrerequisite(new LevelPrerequisite(113));

		AddObjective("kill0", "Kill 10 Phyracon(s)", new KillObjective(10, MonsterId.Flight_Hope));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 2712));

		AddDialogHook("FTOWER41_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER41_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FTOWER41_SQ_01_ST", "FTOWER41_SQ_01", "I'll help you", "About the current situation of the tower", "I'm busy"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FTOWER41_SQ_01_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FTOWER41_SQ_01_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FTOWER41_SQ_02");
	}
}

