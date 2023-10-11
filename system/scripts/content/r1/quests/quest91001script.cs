//--- Melia Script -----------------------------------------------------------
// Unpredictable Movement
//--- Description -----------------------------------------------------------
// Quest to Talk to the Chronomancer Master.
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

[QuestScript(91001)]
public class Quest91001Script : QuestScript
{
	protected override void Load()
	{
		SetId(91001);
		SetName("Unpredictable Movement");
		SetDescription("Talk to the Chronomancer Master");

		AddPrerequisite(new LevelPrerequisite(400));

		AddDialogHook("MASTER_CHRONO", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_CHRONO", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHRONO_RAID_QUEST_DLG01", "CHRONO_RAID_QUEST", "I will help.", "I don't wanna take the risk."))
		{
			case 1:
				await dialog.Msg("CHRONO_RAID_QUEST_DLG02");
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

		await dialog.Msg("CHRONO_RAID_QUEST_DLG03");
		dialog.UnHideNPC("LEGEND_RAID_MORINGPONIA_PORTAL");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

