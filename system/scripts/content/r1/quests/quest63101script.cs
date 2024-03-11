//--- Melia Script -----------------------------------------------------------
// [Tutorial] Dialogue and Interaction
//--- Description -----------------------------------------------------------
// Quest to Talk to the refugee.
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

[QuestScript(63101)]
public class Quest63101Script : QuestScript
{
	protected override void Load()
	{
		SetId(63101);
		SetName("[Tutorial] Dialogue and Interaction");
		SetDescription("Talk to the refugee");

		AddPrerequisite(new LevelPrerequisite(440));
		AddPrerequisite(new CompletedPrerequisite("EP14_3LINE_TUTO_MQ_1"));

		AddDialogHook("EP14_MULIA_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("EP14_3LINE_TUTO_MQ_1_1_3");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Scroll, "Talk to the Illusion of the Girl ");
		// Func/SCR_SKIP_TUTO_SET_CLREAR_RUN_QUEST;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP14_3LINE_TUTO_MQ_1_2");
	}
}

