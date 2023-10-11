//--- Melia Script -----------------------------------------------------------
// Like An Invincible Wall [Rodelero Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Rodelero Master.
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

[QuestScript(70323)]
public class Quest70323Script : QuestScript
{
	protected override void Load()
	{
		SetId(70323);
		SetName("Like An Invincible Wall [Rodelero Advancement]");
		SetDescription("Talk to the Rodelero Master");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("JOB_2_RODELERO_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_RODELERO_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_RODELERO4_1_1", "JOB_2_RODELERO4", "I'll bring the upgraded shield.", "I will come back later"))
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


		return HookResult.Break;
	}
}

