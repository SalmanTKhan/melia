//--- Melia Script -----------------------------------------------------------
// Demon Cauldron (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Herbalist Talas.
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

[QuestScript(50114)]
public class Quest50114Script : QuestScript
{
	protected override void Load()
	{
		SetId(50114);
		SetName("Demon Cauldron (1)");
		SetDescription("Talk to Herbalist Talas");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN_63_3_SQ010"));

		AddReward(new ExpReward(75978, 75978));
		AddReward(new ItemReward("expCard3", 5));
		AddReward(new ItemReward("Vis", 504));

		AddDialogHook("BRACKEN633_PEAPLE01", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN633_PEAPLE01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN_63_3_SQ020_startnpc01", "BRACKEN_63_3_SQ020", "It's best to destroy the cauldron", "It will be fine"))
		{
			case 1:
				await dialog.Msg("BRACKEN_63_3_SQ020_startnpc_prog01");
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

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("BRACKEN_63_3_SQ030");
	}
}

