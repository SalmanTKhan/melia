//--- Melia Script -----------------------------------------------------------
// Track Down the Beholder
//--- Description -----------------------------------------------------------
// Quest to Talk to Inesa Hamondale.
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

[QuestScript(91163)]
public class Quest91163Script : QuestScript
{
	protected override void Load()
	{
		SetId(91163);
		SetName("Track Down the Beholder");
		SetDescription("Talk to Inesa Hamondale");

		AddPrerequisite(new LevelPrerequisite(470));
		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE5_MQ_9"));

		AddDialogHook("C_ORSHA_HAMONDAIL", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_2_1_Lamin1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ep14_2_START_quest_DLG1", "ep14_2_START_quest", "I'll join.", "I'm not ready yet."))
		{
			case 1:
				await dialog.Msg("ep14_2_START_quest_DLG2");
				dialog.UnHideNPC("WARP_EP14_1_F_CASTLE_5_TO_EP14_2_D_CASTLE_1");
				dialog.UnHideNPC("EP14_2_PORTAL1");
				dialog.UnHideNPC("EP14_2_PORTAL2");
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

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP14_2_DCASTLE1_MQ_1");
	}
}

