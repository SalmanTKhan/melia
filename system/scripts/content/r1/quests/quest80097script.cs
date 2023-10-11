//--- Melia Script -----------------------------------------------------------
// The shadow of the monastery
//--- Description -----------------------------------------------------------
// Quest to Talk to the abbot.
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

[QuestScript(80097)]
public class Quest80097Script : QuestScript
{
	protected override void Load()
	{
		SetId(80097);
		SetName("The shadow of the monastery");
		SetDescription("Talk to the abbot");

		AddPrerequisite(new LevelPrerequisite(232));
		AddPrerequisite(new CompletedPrerequisite("ABBEY_35_4_SQ_8"));

		AddObjective("kill0", "Kill 10 Brown Harugal(s) or Brown Hohen Mane(s) or Green Hohen Orben(s)", new KillObjective(10, 57980, 57968, 57976));

		AddReward(new ExpReward(1082046, 1082046));
		AddReward(new ItemReward("expCard11", 4));
		AddReward(new ItemReward("Vis", 8352));

		AddDialogHook("ABBEY_35_4_ELDER_2", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY_35_4_ELDER_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY_35_4_SQ_9_start", "ABBEY_35_4_SQ_9", "Leave it to me", "I'm busy now"))
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

		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You've defeated the demons at the Elgos Monastery");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

