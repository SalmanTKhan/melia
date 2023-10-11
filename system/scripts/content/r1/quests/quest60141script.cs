//--- Melia Script -----------------------------------------------------------
// Everything Intact (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Bishop Urbonas.
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

[QuestScript(60141)]
public class Quest60141Script : QuestScript
{
	protected override void Load()
	{
		SetId(60141);
		SetName("Everything Intact (2)");
		SetDescription("Talk to Bishop Urbonas");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("PRISON623_MQ_06"));

		AddDialogHook("PRISON621_URBONAS", "BeforeStart", BeforeStart);
		AddDialogHook("C_ORSHA_HAMONDAIL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON623_MQ_07_01", "PRISON623_MQ_07", "I'll go back to Orsha", "There are still some things to do"))
		{
			case 1:
				await dialog.Msg("PRISON623_MQ_07_AG");
				await dialog.Msg("FadeOutIN/2500");
				dialog.HideNPC("PRISON621_URBONAS");
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

