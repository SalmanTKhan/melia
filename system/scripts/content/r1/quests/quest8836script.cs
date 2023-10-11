//--- Melia Script -----------------------------------------------------------
// Surviving Lie
//--- Description -----------------------------------------------------------
// Quest to Talk to Adjutant General Hans.
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

[QuestScript(8836)]
public class Quest8836Script : QuestScript
{
	protected override void Load()
	{
		SetId(8836);
		SetName("Surviving Lie");
		SetDescription("Talk to Adjutant General Hans");

		AddPrerequisite(new LevelPrerequisite(193));

		AddReward(new ExpReward(1189715, 1189715));
		AddReward(new ItemReward("expCard10", 1));
		AddReward(new ItemReward("Vis", 5983));

		AddDialogHook("FLASH63_HANS", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH63_HANS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH63_SQ_04_01", "FLASH63_SQ_04", "Yeah, I'll collect them", "About the records", "Decline"))
		{
			case 1:
				dialog.UnHideNPC("FLASH63_SQ_04_NPC");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FLASH63_SQ_04_01_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FLASH63_SQ_04_03");
		dialog.HideNPC("FLASH63_SQ_04_NPC");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

