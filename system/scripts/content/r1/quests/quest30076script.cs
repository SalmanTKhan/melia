//--- Melia Script -----------------------------------------------------------
// Magical Piece of Ice [Cryomancer Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Cryomancer Submaster.
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

[QuestScript(30076)]
public class Quest30076Script : QuestScript
{
	protected override void Load()
	{
		SetId(30076);
		SetName("Magical Piece of Ice [Cryomancer Advancement]");
		SetDescription("Talk to the Cryomancer Submaster");

		AddPrerequisite(new LevelPrerequisite(15));

		AddDialogHook("JOB_2_CRYOMANCER_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_CRYOMANCER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_CRYOMANCER_2_1_select", "JOB_2_CRYOMANCER_2_1", "What do I need to do?", "I'm not so sure about it"))
		{
			case 1:
				await dialog.Msg("JOB_2_CRYOMANCER_2_1_agree");
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

		await dialog.Msg("JOB_2_CRYOMANCER_2_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

