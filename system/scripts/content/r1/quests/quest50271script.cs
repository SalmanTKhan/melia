//--- Melia Script -----------------------------------------------------------
// Wandering Spirit
//--- Description -----------------------------------------------------------
// Quest to Talk to the Lost Spirit.
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

[QuestScript(50271)]
public class Quest50271Script : QuestScript
{
	protected override void Load()
	{
		SetId(50271);
		SetName("Wandering Spirit");
		SetDescription("Talk to the Lost Spirit");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("KATYN_12_MQ_10"));

		AddReward(new ItemReward("Collection_Base_KATYN12_HQ1", 1));

		AddDialogHook("KATYN12_HQ1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN12_RP_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN12_HQ1_start1", "KATYN12_HQ1", "I'll bring any spirits to the Frail Owl Sculpture.", "Well, go luck on your own. See ya."))
		{
			case 1:
				await dialog.Msg("KATYN12_HQ1_agree1");
				dialog.HideNPC("KATYN12_HQ1_NPC");
				// Func/KATYN12_HIDDENQ1_AI_CREATE;
				character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Bring the lost spirit to the Frail Owl Sculpture.");
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

