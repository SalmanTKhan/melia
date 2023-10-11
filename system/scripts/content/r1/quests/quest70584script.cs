//--- Melia Script -----------------------------------------------------------
// Destroy the Second Device
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Stella.
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

[QuestScript(70584)]
public class Quest70584Script : QuestScript
{
	protected override void Load()
	{
		SetId(70584);
		SetName("Destroy the Second Device");
		SetDescription("Talk to Monk Stella");

		AddPrerequisite(new LevelPrerequisite(271));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_5_SQ04"));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 11111));

		AddDialogHook("PILGRIM415_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM415_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM415_SQ_05_start", "PILGRIM41_5_SQ05", "Alright", "Tell them to call Mattas to help"))
		{
			case 1:
				await dialog.Msg("PILGRIM415_SQ_05_agree");
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

		await dialog.Msg("PILGRIM415_SQ_05_succ");
		dialog.HideNPC("PILGRIM415_SQ_05");
		dialog.UnHideNPC("PILGRIM415_SQ_10_2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

