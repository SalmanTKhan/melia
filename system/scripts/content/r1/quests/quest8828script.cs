//--- Melia Script -----------------------------------------------------------
// Lost Time
//--- Description -----------------------------------------------------------
// Quest to Talk to Chronomancer Sabina.
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

[QuestScript(8828)]
public class Quest8828Script : QuestScript
{
	protected override void Load()
	{
		SetId(8828);
		SetName("Lost Time");
		SetDescription("Talk to Chronomancer Sabina");

		AddPrerequisite(new LevelPrerequisite(190));

		AddReward(new ExpReward(1189715, 1189715));
		AddReward(new ItemReward("expCard10", 1));
		AddReward(new ItemReward("Vis", 5890));

		AddDialogHook("FLASH61_SABINA", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH61_SABINA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH61_SQ_07_01", "FLASH61_SQ_07", "I'll do it", "About the truth", "Decline"))
		{
			case 1:
				dialog.UnHideNPC("FLASH61_SQ_07_NPC");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FLASH61_SQ_07_01_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FLASH61_SQ_07_03");
		dialog.HideNPC("FLASH61_SQ_07_NPC");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

