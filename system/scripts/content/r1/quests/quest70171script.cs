//--- Melia Script -----------------------------------------------------------
// Clean Inside
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Moheim.
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

[QuestScript(70171)]
public class Quest70171Script : QuestScript
{
	protected override void Load()
	{
		SetId(70171);
		SetName("Clean Inside");
		SetDescription("Talk to Monk Moheim");

		AddPrerequisite(new LevelPrerequisite(183));
		AddPrerequisite(new CompletedPrerequisite("ABBEY39_4_MQ10"));

		AddObjective("kill0", "Kill 15 Orange Kowak(s) or Malstatue(s) or Pumpleflap(s) or Velaphid(s)", new KillObjective(15, 57355, 57681, 57665, 57676));

		AddReward(new ExpReward(1256004, 1256004));
		AddReward(new ItemReward("expCard9", 4));
		AddReward(new ItemReward("Vis", 5673));

		AddDialogHook("ABBEY394_MQ_07", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY394_MQ_07", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY39_4_SQ_02_1", "ABBEY39_4_SQ02", "I will defeat the monsters inside.", "Go out to a safe area."))
		{
			case 1:
				await dialog.Msg("ABBEY39_4_SQ_02_2");
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

		await dialog.Msg("ABBEY39_4_SQ_02_4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

