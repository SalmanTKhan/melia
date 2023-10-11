//--- Melia Script -----------------------------------------------------------
// Check the Detector's Functionality (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Meile.
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

[QuestScript(40820)]
public class Quest40820Script : QuestScript
{
	protected override void Load()
	{
		SetId(40820);
		SetName("Check the Detector's Functionality (5)");
		SetDescription("Talk to Kupole Meile");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FLASH_29_1_SQ_050_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(204));
		AddPrerequisite(new CompletedPrerequisite("FLASH_29_1_SQ_045"));

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("Vis", 7140));

		AddDialogHook("FLASH_29_1_KUPOLE_MEILE", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH_29_1_DETECTOR01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH_29_1_SQ_050_ST", "FLASH_29_1_SQ_050", "I will go fix the petrification detector", "I need a moment to prepare more"))
		{
			case 1:
				await dialog.Msg("FLASH_29_1_SQ_050_AC");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		ZoneServer.Instance.World.FindNPC("FLASH_29_1_DETECTOR01")?.PlayEffectLocal(character.Connection, "I_spread_out001_light_violet2", 2f, "MID");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "The detector starts to activate!");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

