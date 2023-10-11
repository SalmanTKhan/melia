//--- Melia Script -----------------------------------------------------------
// Eyes of Zachariel (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Archivist Jonas.
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

[QuestScript(4437)]
public class Quest4437Script : QuestScript
{
	protected override void Load()
	{
		SetId(4437);
		SetName("Eyes of Zachariel (1)");
		SetDescription("Talk to Archivist Jonas");

		AddPrerequisite(new LevelPrerequisite(58));
		AddPrerequisite(new CompletedPrerequisite("ROKAS24_QB_8"));

		AddDialogHook("ROKAS_24_FLORIJONAS3", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS_24_FLORIJONAS3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS24_QB_10_ST", "ROKAS24_QB_10", "I am qualified", "About the secret treasures of the Great King", "I won't need it"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("ROKAS24_QB_10_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("ROKAS24_QB_10_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

