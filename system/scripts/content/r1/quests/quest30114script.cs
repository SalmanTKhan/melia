//--- Melia Script -----------------------------------------------------------
// The Bravery That Never Backs Down [Dragoon Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with the Dragoon Master.
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

[QuestScript(30114)]
public class Quest30114Script : QuestScript
{
	protected override void Load()
	{
		SetId(30114);
		SetName("The Bravery That Never Backs Down [Dragoon Advancement]");
		SetDescription("Talk with the Dragoon Master");

		AddPrerequisite(new LevelPrerequisite(235));

		AddDialogHook("DRAGOON_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("DRAGOON_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_DRAGOON_7_1_select", "JOB_DRAGOON_7_1", "Shouldn't be a problem", "I wish to avoid the difficult path"))
		{
			case 1:
				await dialog.Msg("JOB_DRAGOON_7_1_agree");
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

		await dialog.Msg("JOB_DRAGOON_7_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

