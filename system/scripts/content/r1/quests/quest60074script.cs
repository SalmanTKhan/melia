//--- Melia Script -----------------------------------------------------------
// Orsha (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Mayor Romanas.
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

[QuestScript(60074)]
public class Quest60074Script : QuestScript
{
	protected override void Load()
	{
		SetId(60074);
		SetName("Orsha (1)");
		SetDescription("Talk with Mayor Romanas");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("SIAU16_MQ_04"));

		AddDialogHook("SIAULIAI16_ROMANAS", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI16_LUTAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAU16_MQ_05_01", "SIAU16_MQ_05", "I will go", "Tell me about Medzio Diena", "I have other things to do"))
		{
			case 1:
				await dialog.Msg("SIAU16_MQ_05_01_AG");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("SIAU16_MQ_05_01_add");
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

