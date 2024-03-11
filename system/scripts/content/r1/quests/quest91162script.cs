//--- Melia Script -----------------------------------------------------------
// To the Turbulent Core
//--- Description -----------------------------------------------------------
// Quest to Clear [Goddess Raid: Turbulent Core].
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

[QuestScript(91162)]
public class Quest91162Script : QuestScript
{
	protected override void Load()
	{
		SetId(91162);
		SetName("To the Turbulent Core");
		SetDescription("Clear [Goddess Raid: Turbulent Core]");

		AddPrerequisite(new LevelPrerequisite(480));
		AddPrerequisite(new CompletedPrerequisite("RAID_CASTLE_EP14_2_MQ_1"));

		AddDialogHook("RAID_CASTLE_EP14_2_PORTAL", "BeforeStart", BeforeStart);
		AddDialogHook("RAID_CASTLE_EP14_2_SOLD", "BeforeEnd", BeforeEnd);
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

		// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
		await dialog.Msg("RAID_CASTLE_EP14_2_MQ_2_DLG1");
		await dialog.Msg("FadeOutIN/3000");
		dialog.HideNPC("RAID_CASTLE_EP14_2_SOLD");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

