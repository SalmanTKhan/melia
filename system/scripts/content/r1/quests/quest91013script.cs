//--- Melia Script -----------------------------------------------------------
// White Witch and the Crusader(6)
//--- Description -----------------------------------------------------------
// Quest to Talk to Crusader Envoy.
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

[QuestScript(91013)]
public class Quest91013Script : QuestScript
{
	protected override void Load()
	{
		SetId(91013);
		SetName("White Witch and the Crusader(6)");
		SetDescription("Talk to Crusader Envoy");

		AddPrerequisite(new LevelPrerequisite(440));
		AddPrerequisite(new CompletedPrerequisite("F_TABLELAND_28_2_RAID_06"));

		AddReward(new ItemReward("expCard17", 2));
		AddReward(new ItemReward("Vis", 26840));

		AddDialogHook("NPC_CRUSADER_01", "BeforeStart", BeforeStart);
		AddDialogHook("NPC_CRUSADER_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_TABLELAND_28_2_RAID_DLG23", "F_TABLELAND_28_2_RAID_07", "Tell him you will go there", "I have other things to do."))
		{
			case 1:
				await dialog.Msg("F_TABLELAND_28_2_RAID_DLG24");
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

		await dialog.Msg("F_TABLELAND_28_2_RAID_DLG26");
		await dialog.Msg("F_TABLELAND_28_2_RAID_DLG27");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

