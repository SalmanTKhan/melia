//--- Melia Script -----------------------------------------------------------
// Hostile Extortion
//--- Description -----------------------------------------------------------
// Quest to Talk to Grave Robber Hubertas.
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

[QuestScript(8807)]
public class Quest8807Script : QuestScript
{
	protected override void Load()
	{
		SetId(8807);
		SetName("Hostile Extortion");
		SetDescription("Talk to Grave Robber Hubertas");

		AddPrerequisite(new LevelPrerequisite(184));

		AddReward(new ExpReward(1256004, 1256004));
		AddReward(new ItemReward("expCard9", 4));
		AddReward(new ItemReward("Vis", 5704));

		AddDialogHook("FLASH59_HUBERTAS", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH59_HUBERTAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH59_SQ_08_01", "FLASH59_SQ_08", "Tell him that you would bring the goods", "About the Dico Thieves", "Tell him that you don't want to steal"))
		{
			case 1:
				dialog.UnHideNPC("FLASH59_SQ_08_NPC");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FLASH59_SQ_08_01_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FLASH59_SQ_08_03");
		dialog.HideNPC("FLASH59_SQ_08_NPC");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}
