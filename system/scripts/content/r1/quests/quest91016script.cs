//--- Melia Script -----------------------------------------------------------
// White Witch and the Crusader(8)
//--- Description -----------------------------------------------------------
// Quest to Find Crusader Master..
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

[QuestScript(91016)]
public class Quest91016Script : QuestScript
{
	protected override void Load()
	{
		SetId(91016);
		SetName("White Witch and the Crusader(8)");
		SetDescription("Find Crusader Master.");

		AddPrerequisite(new LevelPrerequisite(450));
		AddPrerequisite(new CompletedPrerequisite("F_TABLELAND_28_2_RAID_08"));

		AddReward(new ItemReward("expCard17", 1));
		AddReward(new ItemReward("Vis", 27900));

		AddDialogHook("MASTER_CRUSADER_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_CRUSADER_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_TABLELAND_28_2_RAID_DLG30", "F_TABLELAND_28_2_RAID_09", "Cooperate with the investigation.", "Won't cooperate with the investigation."))
		{
			case 1:
				await dialog.Msg("F_TABLELAND_28_2_RAID_DLG31");
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

		await dialog.Msg("F_TABLELAND_28_2_RAID_DLG33");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("F_TABLELAND_28_2_RAID_10");
	}
}

