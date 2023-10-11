//--- Melia Script -----------------------------------------------------------
// Too Many Seals (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sealed Stone.
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

[QuestScript(17014)]
public class Quest17014Script : QuestScript
{
	protected override void Load()
	{
		SetId(17014);
		SetName("Too Many Seals (1)");
		SetDescription("Talk to the Sealed Stone");

		AddPrerequisite(new LevelPrerequisite(119));

		AddObjective("kill0", "Kill 10 Arma(s)", new KillObjective(10, MonsterId.Arma));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 2856));

		AddDialogHook("FTOWER43_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER43_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FTOWER43_SQ_03_ST", "FTOWER43_SQ_03", "Seems suspicious but grant his wish", "Just ignore it"))
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

		await dialog.Msg("FTOWER43_SQ_03_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FTOWER43_SQ_04");
	}
}

