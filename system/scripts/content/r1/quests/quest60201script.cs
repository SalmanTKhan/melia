//--- Melia Script -----------------------------------------------------------
// Back in time(2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Chronomancer Master.
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

[QuestScript(60201)]
public class Quest60201Script : QuestScript
{
	protected override void Load()
	{
		SetId(60201);
		SetName("Back in time(2)");
		SetDescription("Talk to the Chronomancer Master");

		AddPrerequisite(new LevelPrerequisite(308));
		AddPrerequisite(new CompletedPrerequisite("FIRETOWER691_PRE_1"));

		AddDialogHook("MASTER_CHRONO", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FIRETOWER691_PRE_2_1", "FIRETOWER691_PRE_2", "I'll go there", "I need to prepare"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FIRETOWER691_MQ_1");
	}
}

