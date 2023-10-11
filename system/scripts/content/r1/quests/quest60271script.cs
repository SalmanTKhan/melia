//--- Melia Script -----------------------------------------------------------
// The History that Will Not Be Recorded (9)
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

[QuestScript(60271)]
public class Quest60271Script : QuestScript
{
	protected override void Load()
	{
		SetId(60271);
		SetName("The History that Will Not Be Recorded (9)");
		SetDescription("Talk to Goddess Vaivora");

		AddPrerequisite(new LevelPrerequisite(344));
		AddPrerequisite(new CompletedPrerequisite("FANTASYLIB484_MQ_8"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 6));

		AddDialogHook("FLIBRARY484_VIVORA_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("FLIBRARY485_NERINGA_FLLW_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FANTASYLIB484_MQ_9_1", "FANTASYLIB484_MQ_9", "I will confront Giltine.", "Don't talk."))
		{
			case 1:
				await dialog.Msg("FANTASYLIB484_MQ_9_1_1");
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

		await dialog.Msg("FANTASYLIB484_MQ_9_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

