//--- Melia Script -----------------------------------------------------------
// The Sealed Tower of the Goddess (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Ramelie.
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

[QuestScript(50045)]
public class Quest50045Script : QuestScript
{
	protected override void Load()
	{
		SetId(50045);
		SetName("The Sealed Tower of the Goddess (2)");
		SetDescription("Talk to Priest Ramelie");

		AddPrerequisite(new LevelPrerequisite(100));
		AddPrerequisite(new CompletedPrerequisite("PARTY_Q_100"));

		AddDialogHook("SIAULIAI_46_2_MQ01_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_46_2_SEAL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PARTY_Q_101_startnpc01", "PARTY_Q_101", "I will help the rest", "Say Farewell"))
		{
			case 1:
				await dialog.Msg("PARTY_Q_101_startnpc02");
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

