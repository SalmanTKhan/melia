//--- Melia Script -----------------------------------------------------------
// A World Composed of Numbers [Kabbalist Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with the Kabbalist Master.
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

[QuestScript(30121)]
public class Quest30121Script : QuestScript
{
	protected override void Load()
	{
		SetId(30121);
		SetName("A World Composed of Numbers [Kabbalist Advancement]");
		SetDescription("Talk with the Kabbalist Master");

		AddPrerequisite(new LevelPrerequisite(235));

		AddDialogHook("KABBALIST_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("KABBALIST_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_KABBALIST_7_1_select", "JOB_KABBALIST_7_1", "I want to experience it", "I decline complicated things"))
		{
			case 1:
				await dialog.Msg("JOB_KABBALIST_7_1_agree");
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

		await dialog.Msg("JOB_KABBALIST_7_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

