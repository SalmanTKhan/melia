//--- Melia Script -----------------------------------------------------------
// What happened to the monastery?
//--- Description -----------------------------------------------------------
// Quest to Talk to Edmundas.
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

[QuestScript(50142)]
public class Quest50142Script : QuestScript
{
	protected override void Load()
	{
		SetId(50142);
		SetName("What happened to the monastery?");
		SetDescription("Talk to Edmundas");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ABBAY_64_3_MQ050"));

		AddReward(new ExpReward(16884, 16884));
		AddReward(new ItemReward("expCard3", 2));
		AddReward(new ItemReward("Vis", 11088891));

		AddDialogHook("ABBEY643_EDMONDA04", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY643_EDMONDA04", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBAY_64_3_SQ050_startnpc01", "ABBAY_64_3_SQ050", "I'll find the experiment journal", "I'll find it myself"))
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

		await dialog.Msg("ABBAY_64_3_SQ050_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

