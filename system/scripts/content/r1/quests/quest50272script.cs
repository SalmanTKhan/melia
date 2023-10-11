//--- Melia Script -----------------------------------------------------------
// The Inmates' Secret Spots
//--- Description -----------------------------------------------------------
// Quest to Open the Inmates' Hidden Locking Device.
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

[QuestScript(50272)]
public class Quest50272Script : QuestScript
{
	protected override void Load()
	{
		SetId(50272);
		SetName("The Inmates' Secret Spots");
		SetDescription("Open the Inmates' Hidden Locking Device");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ItemReward("Collection_Base_PRISON62_2_HQ1", 1));

		AddDialogHook("PRISON622_HIDDEN_OBJ6", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON622_HIDDEN_OBJ6", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON62_2_HQ1_start1", "PRISON62_2_HQ1", "I'll open it.", "Just leave it"))
		{
			case 1:
				character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "The box is locked with a device.{nl}Find a way to unlock it.");
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

