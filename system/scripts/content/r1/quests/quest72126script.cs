//--- Melia Script -----------------------------------------------------------
// Reducing as Much as Possible
//--- Description -----------------------------------------------------------
// Quest to Talk to Leonardas.
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

[QuestScript(72126)]
public class Quest72126Script : QuestScript
{
	protected override void Load()
	{
		SetId(72126);
		SetName("Reducing as Much as Possible");
		SetDescription("Talk to Leonardas");

		AddPrerequisite(new LevelPrerequisite(336));

		AddObjective("kill0", "Kill 15 Lake Golem(s) or Anchor Golem(s) or Fondus(s)", new KillObjective(15, 58836, 58838, 58837));

		AddReward(new ItemReward("Vis", 3158));

		AddDialogHook("3CMLAKE_LEONARDAS", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_LEONARDAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("3CMLAKE262_SQ12_DLG01", "F_3CMLAKE262_SQ12", "Alright", "I have other appointments."))
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

		await dialog.Msg("3CMLAKE262_SQ12_DLG04");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

