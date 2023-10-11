//--- Melia Script -----------------------------------------------------------
// Relief request of owl image
//--- Description -----------------------------------------------------------
// Quest to Talk with the Sacred Owl Sculpture.
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

[QuestScript(8316)]
public class Quest8316Script : QuestScript
{
	protected override void Load()
	{
		SetId(8316);
		SetName("Relief request of owl image");
		SetDescription("Talk with the Sacred Owl Sculpture");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 8 Desmodus(s)", new KillObjective(8, MonsterId.New_Desmodus));

		AddDialogHook("KATYN18_OWL_03", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN18_OWL_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN18_MQ_10_01", "KATYN18_MQ_10", "I'll get rid of the Desmodus", "Cancel"))
		{
			case 1:
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

		await dialog.Msg("KATYN18_MQ_10_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("KATYN18_MQ_11");
	}
}

