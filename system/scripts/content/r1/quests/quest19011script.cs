//--- Melia Script -----------------------------------------------------------
// Behind closed doors of secret
//--- Description -----------------------------------------------------------
// Quest to Suddenly appeared Swordsman master and conversation.
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

[QuestScript(19011)]
public class Quest19011Script : QuestScript
{
	protected override void Load()
	{
		SetId(19011);
		SetName("Behind closed doors of secret");
		SetDescription("Suddenly appeared Swordsman master and conversation");

		AddPrerequisite(new LevelPrerequisite(9999));
		// Required quest doesn't exist anymore, so disabling requirement.
/**		AddPrerequisite(new CompletedPrerequisite("KATYN_13_2_HQ_05"));
		**/

		AddObjective("kill0", "Kill 70 Banshee(s)", new KillObjective(70, MonsterId.Banshee));

		AddDialogHook("KATYN_13_2_HQ_01_SMASTER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_SWORDMAN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_13_2_HQ_01_ST", "KATYN_13_2_HQ_01", "I will take the test", "Decline"))
		{
			case 1:
				await dialog.Msg("KATYN_13_2_HQ_01_AC");
				await dialog.Msg("FadeOutIN/1000");
				dialog.HideNPC("KATYN_13_2_HQ_01_SMASTER");
				// Func/DESTROY_SESSION;
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

		await dialog.Msg("KATYN_13_2_HQ_01_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

