//--- Melia Script -----------------------------------------------------------
// Opening the road back
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim David.
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

[QuestScript(70553)]
public class Quest70553Script : QuestScript
{
	protected override void Load()
	{
		SetId(70553);
		SetName("Opening the road back");
		SetDescription("Talk to Pilgrim David");

		AddPrerequisite(new LevelPrerequisite(265));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_4_SQ13"));

		AddObjective("kill0", "Kill 12 Yellow Dumaro(s) or Blue Lepusbunny(s)", new KillObjective(12, 57992, 57890));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 10865));

		AddDialogHook("PILGRIM414_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM414_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM414_SQ_14_start", "PILGRIM41_4_SQ14", "Ask them what it is about", "Say that you dislike hard work"))
		{
			case 1:
				await dialog.Msg("PILGRIM414_SQ_14_agree");
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

		await dialog.Msg("PILGRIM414_SQ_14_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

