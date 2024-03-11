//--- Melia Script -----------------------------------------------------------
// Their Ways
//--- Description -----------------------------------------------------------
// Quest to Talk to Grave Robber Hubertas.
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

[QuestScript(8809)]
public class Quest8809Script : QuestScript
{
	protected override void Load()
	{
		SetId(8809);
		SetName("Their Ways");
		SetDescription("Talk to Grave Robber Hubertas");

		AddPrerequisite(new LevelPrerequisite(184));

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 5704));

		AddDialogHook("FLASH59_HUBERTAS", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH59_BENJAMINAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH59_SQ_10_01", "FLASH59_SQ_10", "I'll deliver it for you", "The way to avoid Petrifying Frost", "Decline"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FLASH59_SQ_10_01_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FLASH59_SQ_10_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

