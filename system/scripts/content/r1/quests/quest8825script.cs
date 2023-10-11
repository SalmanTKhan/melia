//--- Melia Script -----------------------------------------------------------
// Treading a Tail
//--- Description -----------------------------------------------------------
// Quest to Talk to Guard Nomabis.
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

[QuestScript(8825)]
public class Quest8825Script : QuestScript
{
	protected override void Load()
	{
		SetId(8825);
		SetName("Treading a Tail");
		SetDescription("Talk to Guard Nomabis");

		AddPrerequisite(new LevelPrerequisite(190));

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("Vis", 5890));

		AddDialogHook("FLASH61_NOBAVIS", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH61_NOBAVIS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH61_SQ_04_01", "FLASH61_SQ_04", "Alright, I'll help you", "About the Dico Thieves", "That's too much"))
		{
			case 1:
				dialog.UnHideNPC("FLASH61_SQ_04_NPC");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FLASH61_SQ_04_01_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FLASH61_SQ_04_03");
		dialog.HideNPC("FLASH61_SQ_04_NPC");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

