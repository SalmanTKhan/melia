//--- Melia Script -----------------------------------------------------------
// What the Numbers Signify [Kabbalist Advancement]
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

[QuestScript(50243)]
public class Quest50243Script : QuestScript
{
	protected override void Load()
	{
		SetId(50243);
		SetName("What the Numbers Signify [Kabbalist Advancement]");
		SetDescription("Talk with the Kabbalist Master");

		AddPrerequisite(new LevelPrerequisite(285));

		AddDialogHook("KABBALIST_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("KABBALIST_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_KABBALIST_8_1_START1", "JOB_KABBALIST_8_1", "Heck, you only live once, right? I will do it.", "I want to try something else."))
		{
			case 1:
				await dialog.Msg("JOB_KABBALIST_8_1_AGREE1");
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

		await dialog.Msg("JOB_KABBALIST_8_1_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

