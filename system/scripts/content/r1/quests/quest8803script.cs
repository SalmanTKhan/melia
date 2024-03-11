//--- Melia Script -----------------------------------------------------------
// Petrifying Frost Forecast (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Royal Army Guard Retia.
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

[QuestScript(8803)]
public class Quest8803Script : QuestScript
{
	protected override void Load()
	{
		SetId(8803);
		SetName("Petrifying Frost Forecast (2)");
		SetDescription("Talk to Royal Army Guard Retia");

		AddPrerequisite(new LevelPrerequisite(184));
		AddPrerequisite(new CompletedPrerequisite("FLASH59_SQ_03"));

		AddReward(new ExpReward(1046670, 1046670));
		AddReward(new ItemReward("expCard9", 1));
		AddReward(new ItemReward("Vis", 5704));

		AddDialogHook("FLASH59_RETIA", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH59_RETIA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH59_SQ_04_01", "FLASH59_SQ_04", "Tell him that you can get rid of it", "That's too much"))
		{
			case 1:
				await dialog.Msg("FLASH59_SQ_04_01_01");
				dialog.UnHideNPC("FLASH59_SQ_04_NPC");
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

		await dialog.Msg("FLASH59_SQ_04_03");
		dialog.HideNPC("FLASH59_SQ_04_NPC");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

