//--- Melia Script -----------------------------------------------------------
// Recruiting New Members
//--- Description -----------------------------------------------------------
// Quest to Talk to Leopoldas.
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

[QuestScript(41610)]
public class Quest41610Script : QuestScript
{
	protected override void Load()
	{
		SetId(41610);
		SetName("Recruiting New Members");
		SetDescription("Talk to Leopoldas");

		AddPrerequisite(new LevelPrerequisite(110));

		AddDialogHook("PILGRIM_48_LEOPOLDAS", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM_48_LEOPOLDAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM_48_SQ_010_.ST", "PILGRIM_48_SQ_010", "Shake head", "I don't have time for that"))
		{
			case 1:
				await dialog.Msg("PILGRIM_48_SQ_010_AC");
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

		await dialog.Msg("PILGRIM_48_SQ_010_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

