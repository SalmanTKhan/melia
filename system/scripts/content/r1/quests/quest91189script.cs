//--- Melia Script -----------------------------------------------------------
// Thurible of Salvation
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Ruta.
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

[QuestScript(91189)]
public class Quest91189Script : QuestScript
{
	protected override void Load()
	{
		SetId(91189);
		SetName("Thurible of Salvation");
		SetDescription("Talk to Kupole Ruta");

		AddPrerequisite(new LevelPrerequisite(490));
		AddPrerequisite(new CompletedPrerequisite("RAID_ABBEY_EP15_1_MQ_1"));

		AddDialogHook("RAID_EP15_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("RAID_EP15_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("RAID_ABBEY_EP15_1_MQ_2_DLG1", "RAID_ABBEY_EP15_1_MQ_2", "I'll solve it.", "I'll be off to do something else."))
		{
			case 1:
				await dialog.Msg("RAID_ABBEY_EP15_1_MQ_2_DLG2");
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

		await dialog.Msg("RAID_ABBEY_EP15_1_MQ_2_DLG3");
		dialog.HideNPC("RAID_EP15_1_NPC");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

