//--- Melia Script -----------------------------------------------------------
// Not Able to Meet Again
//--- Description -----------------------------------------------------------
// Quest to Talk to the resentful soul.
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

[QuestScript(9105)]
public class Quest9105Script : QuestScript
{
	protected override void Load()
	{
		SetId(9105);
		SetName("Not Able to Meet Again");
		SetDescription("Talk to the resentful soul");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("HUEVILLAGE_58_3_HQ01_NPC03", "BeforeStart", BeforeStart);
		AddDialogHook("HUEVILLAGE_58_3_KLAIPEDA_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("HUEVILLAGE_58_3_HQ_01_select01", "HUEVILLAGE_58_3_HQ_01", "I will find your sister and give her the necklace", "Decline"))
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


		return HookResult.Break;
	}
}

