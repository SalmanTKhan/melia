//--- Melia Script -----------------------------------------------------------
// Designated Area (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Watcher Molly.
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

[QuestScript(50032)]
public class Quest50032Script : QuestScript
{
	protected override void Load()
	{
		SetId(50032);
		SetName("Designated Area (2)");
		SetDescription("Talk to Watcher Molly");

		AddPrerequisite(new LevelPrerequisite(100));
		AddPrerequisite(new CompletedPrerequisite("PARTY_Q_030"));

		AddDialogHook("GELE571_NPC_MARLEY", "BeforeStart", BeforeStart);
		AddDialogHook("GELE571_NPC_MARLEY", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PARTY_Q_031_startnpc01", "PARTY_Q_031", "I will install it", "I'll get going then"))
		{
			case 1:
				dialog.UnHideNPC("PARTY_Q3_GELE01");
				dialog.UnHideNPC("PARTY_Q3_GELE02");
				dialog.UnHideNPC("PARTY_Q3_GELE03");
				dialog.UnHideNPC("PARTY_Q3_GELE04");
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

		await dialog.Msg("PARTY_Q_031_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

