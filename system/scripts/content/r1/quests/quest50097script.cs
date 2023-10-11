//--- Melia Script -----------------------------------------------------------
// The Injured Herbalist (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Herbalist Tales.
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

[QuestScript(50097)]
public class Quest50097Script : QuestScript
{
	protected override void Load()
	{
		SetId(50097);
		SetName("The Injured Herbalist (2)");
		SetDescription("Talk to Herbalist Tales");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN_63_1_SQ030"));

		AddDialogHook("BRACKEN631_PEAPLE01", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_CLERIC_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN_63_1_SQ040_startnpc01", "BRACKEN_63_1_SQ040", "Ask him if there's anything you can help", "Go back to the village fast"))
		{
			case 1:
				await dialog.Msg("BRACKEN_63_1_SQ040_startnpc02");
				character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Tell the Cleric Master in Orsha about Herbalist Tales' symptoms");
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
		character.Quests.Start("BRACKEN_63_1_SQ050");
	}
}

