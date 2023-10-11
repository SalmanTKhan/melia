//--- Melia Script -----------------------------------------------------------
// A Suspicious Stranger
//--- Description -----------------------------------------------------------
// Quest to Talk to Senior Monk Goss.
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

[QuestScript(70142)]
public class Quest70142Script : QuestScript
{
	protected override void Load()
	{
		SetId(70142);
		SetName("A Suspicious Stranger");
		SetDescription("Talk to Senior Monk Goss");

		AddPrerequisite(new LevelPrerequisite(179));
		AddPrerequisite(new CompletedPrerequisite("THORN39_3_MQ02"));

		AddDialogHook("THORN393_MQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("THORN393_MQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN39_3_MQ_03_1", "THORN39_3_MQ03", "I'll deliver it for you", "About the protection of Ebonypawn", "Give me some time"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("THORN39_3_MQ_03_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("THORN39_3_MQ_03_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

