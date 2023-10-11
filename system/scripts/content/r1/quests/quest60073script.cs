//--- Melia Script -----------------------------------------------------------
// The Journey Begins (3)
//--- Description -----------------------------------------------------------
// Quest to Talk with Settler Brophen.
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

[QuestScript(60073)]
public class Quest60073Script : QuestScript
{
	protected override void Load()
	{
		SetId(60073);
		SetName("The Journey Begins (3)");
		SetDescription("Talk with Settler Brophen");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(Or(new CompletedPrerequisite("SIAU16_MQ_03"), new CompletedPrerequisite("SIAU16_MQ_02")));

		AddDialogHook("SIAULIAI16_BROPHEN", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI16_RHEILAR", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAU16_MQ_04_01", "SIAU16_MQ_04", "I will pass it", "I'm busy"))
		{
			case 1:
				character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Follow the path on the right and deliver{nl}the Grass Leaf Ointment to Settler Layla");
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

