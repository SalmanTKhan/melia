//--- Melia Script -----------------------------------------------------------
// Revelator of Moroth (7)
//--- Description -----------------------------------------------------------
// Quest to Talk to Illusion of the Girl .
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

[QuestScript(63109)]
public class Quest63109Script : QuestScript
{
	protected override void Load()
	{
		SetId(63109);
		SetName("Revelator of Moroth (7)");
		SetDescription("Talk to Illusion of the Girl ");

		AddPrerequisite(new LevelPrerequisite(440));
		AddPrerequisite(new CompletedPrerequisite("EP14_3LINE_TUTO_MQ_6"));

		AddDialogHook("EP14_MULIA_NPC_2", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_OWYNIA_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_3LINE_TUTO_MQ_7_1", "EP14_3LINE_TUTO_MQ_7", "I will try", "I will just walk"))
		{
			case 1:
				dialog.ShowHelp("TUTO_TELEPORT");
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

		await dialog.Msg("EP14_3LINE_TUTO_MQ_7_3");
		dialog.HideNPC("EP14_MULIA_NPC_2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP14_3LINE_TUTO_MQ_7_1");
	}
}

