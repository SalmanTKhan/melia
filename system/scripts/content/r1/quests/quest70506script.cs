//--- Melia Script -----------------------------------------------------------
// Where there is clean water
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Angela.
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

[QuestScript(70506)]
public class Quest70506Script : QuestScript
{
	protected override void Load()
	{
		SetId(70506);
		SetName("Where there is clean water");
		SetDescription("Talk to Pilgrim Angela");

		AddPrerequisite(new LevelPrerequisite(258));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_1_SQ06"));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 10320));

		AddDialogHook("PILGRIM411_SQ_07", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM411_SQ_07", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM411_SQ_07_start", "PILGRIM41_1_SQ07", "How can I help you?", "Decline since it is hard work"))
		{
			case 1:
				await dialog.Msg("PILGRIM411_SQ_07_agree");
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

		await dialog.Msg("PILGRIM411_SQ_07_succ");
		dialog.UnHideNPC("PILGRIM411_SQ_07_1");
		await dialog.Msg("FadeOutIN/1000");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

