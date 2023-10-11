//--- Melia Script -----------------------------------------------------------
// The History that Will Not Be Recorded (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Vaivora.
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

[QuestScript(60267)]
public class Quest60267Script : QuestScript
{
	protected override void Load()
	{
		SetId(60267);
		SetName("The History that Will Not Be Recorded (5)");
		SetDescription("Talk to Goddess Vaivora");

		AddPrerequisite(new LevelPrerequisite(344));
		AddPrerequisite(new CompletedPrerequisite("FANTASYLIB484_MQ_4"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 6));

		AddDialogHook("FLIBRARY484_VIVORA_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("FLIBRARY484_SJAIVA_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FANTASYLIB484_MQ_5_1", "FANTASYLIB484_MQ_5", "I will go get it", "I need to take care of something first."))
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

		await dialog.Msg("FANTASYLIB484_MQ_5_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

