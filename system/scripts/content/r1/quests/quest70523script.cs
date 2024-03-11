//--- Melia Script -----------------------------------------------------------
// It is the blessing of the Divine Tree
//--- Description -----------------------------------------------------------
// Quest to Talk to Believer Brutus.
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

[QuestScript(70523)]
public class Quest70523Script : QuestScript
{
	protected override void Load()
	{
		SetId(70523);
		SetName("It is the blessing of the Divine Tree");
		SetDescription("Talk to Believer Brutus");

		AddPrerequisite(new LevelPrerequisite(261));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_2_SQ01"), new CompletedPrerequisite("PILGRIM41_2_SQ02"), new CompletedPrerequisite("PILGRIM41_2_SQ03"));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 10701));

		AddDialogHook("PILGRIM412_SQ_04", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM412_SQ_05", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM412_SQ_04_start", "PILGRIM41_2_SQ04", "Say that you have seem plagued Pilgrims", "Say that you have better things to do"))
		{
			case 1:
				await dialog.Msg("PILGRIM412_SQ_04_agree");
				dialog.UnHideNPC("PILGRIM412_SQ_04");
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

		await dialog.Msg("PILGRIM412_SQ_04_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

