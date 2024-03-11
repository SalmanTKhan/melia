//--- Melia Script -----------------------------------------------------------
// Goddess Jurate's Message
//--- Description -----------------------------------------------------------
// Quest to Speak with Loremaster Ugnius.
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

[QuestScript(90206)]
public class Quest90206Script : QuestScript
{
	protected override void Load()
	{
		SetId(90206);
		SetName("Goddess Jurate's Message");
		SetDescription("Speak with Loremaster Ugnius");

		AddPrerequisite(new LevelPrerequisite(331));
		AddPrerequisite(new CompletedPrerequisite("CORAL_44_2_SQ_60"));

		AddDialogHook("CORAL_44_2_OLDMAN2", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_44_2_OLDMAN2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_44_2_SQ_70_ST", "CORAL_44_2_SQ_70", "There's no problem", "Please wait a bit"))
		{
			case 1:
				dialog.UnHideNPC("CORAL_44_2_SQ_70_EFF");
				await dialog.Msg("NPCAin/CORAL_44_2_OLDMAN2/event_loop3/1");
				await Task.Delay(1500);
				await dialog.Msg("CORAL_44_2_SQ_70_AG");
				dialog.HideNPC("CORAL_44_2_SQ_70_EFF");
				await dialog.Msg("NPCAin/CORAL_44_2_OLDMAN2/std/0");
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

