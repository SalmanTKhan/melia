//--- Melia Script -----------------------------------------------------------
// Orsha (3)
//--- Description -----------------------------------------------------------
// Quest to Talk with Officer Lutas.
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

[QuestScript(60076)]
public class Quest60076Script : QuestScript
{
	protected override void Load()
	{
		SetId(60076);
		SetName("Orsha (3)");
		SetDescription("Talk with Officer Lutas");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("SIAU16_MQ_06"));

		AddDialogHook("SIAULIAI16_LUTAS", "BeforeStart", BeforeStart);
		AddDialogHook("C_ORSHA_HAMONDAIL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAU16_MQ_07_01", "SIAU16_MQ_07", "Tell me about the bishop of Orsha", "There's still things I need to take care of here"))
		{
			case 1:
				await dialog.Msg("SIAU16_MQ_07_01_AG");
				character.AddonMessage(AddonMessage.NOTICE_Dm_Scroll, "Follow the green arrow to visit Orsha", 8);
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

