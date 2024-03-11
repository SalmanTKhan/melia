//--- Melia Script -----------------------------------------------------------
// Edmundas' Worry (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Edmundas.
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

[QuestScript(50138)]
public class Quest50138Script : QuestScript
{
	protected override void Load()
	{
		SetId(50138);
		SetName("Edmundas' Worry (1)");
		SetDescription("Talk to Edmundas");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ABBAY_64_3_MQ050"));

		AddObjective("kill0", "Kill 10 Lapemiter(s) or Deadborn Scap(s) or Lapeman(s) or Brown Hummingbird(s)", new KillObjective(10, 57844, 103027, 57856, 58103));

		AddReward(new ExpReward(50652, 50652));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("Vis", 954));

		AddDialogHook("ABBEY643_EDMONDA04", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY643_EDMONDA04", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBAY_64_3_SQ010_startnpc01", "ABBAY_64_3_SQ010", "I'll chase away the monsters at the Medie State Apartments", "I'll do it later"))
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


		return HookResult.Break;
	}
}

