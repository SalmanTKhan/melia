//--- Melia Script -----------------------------------------------------------
// The Sealed Tower of the Goddess (3)
//--- Description -----------------------------------------------------------
// Quest to Offer the Goddess Austeja's Scripture to the Sealed Tower.
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

[QuestScript(50046)]
public class Quest50046Script : QuestScript
{
	protected override void Load()
	{
		SetId(50046);
		SetName("The Sealed Tower of the Goddess (3)");
		SetDescription("Offer the Goddess Austeja's Scripture to the Sealed Tower");

		AddPrerequisite(new LevelPrerequisite(100));
		AddPrerequisite(new CompletedPrerequisite("PARTY_Q_101"));
		AddPrerequisite(new ItemPrerequisite("PARTY_Q10_CRYSTAL", -100));

		AddDialogHook("SIAULIAI_46_2_SEAL", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_46_2_MQ01_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("PARTY_Q_102_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

