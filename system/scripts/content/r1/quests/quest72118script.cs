//--- Melia Script -----------------------------------------------------------
// Crystal Stone in the Garden (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Demon Lord Solcomm.
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

[QuestScript(72118)]
public class Quest72118Script : QuestScript
{
	protected override void Load()
	{
		SetId(72118);
		SetName("Crystal Stone in the Garden (1)");
		SetDescription("Talk to Demon Lord Solcomm");

		AddPrerequisite(new LevelPrerequisite(336));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE262_SQ03"));

		AddDialogHook("3CMLAKE_SOLCOMM", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("3CMLAKE262_SQ04_DLG01", "F_3CMLAKE262_SQ04", "Alright", "No, I won't get involved. It's too complicated."))
		{
			case 1:
				dialog.UnHideNPC("3CMLAKE262_SQ06_TRUE_STONE");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("F_3CMLAKE262_SQ05");
	}
}

