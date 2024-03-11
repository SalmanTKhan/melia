//--- Melia Script -----------------------------------------------------------
// Cursed Orb
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Prosit.
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

[QuestScript(20338)]
public class Quest20338Script : QuestScript
{
	protected override void Load()
	{
		SetId(20338);
		SetName("Cursed Orb");
		SetDescription("Talk to Priest Prosit");

		AddPrerequisite(new LevelPrerequisite(145));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("PRIST_REPORT03", 1));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 3770));

		AddDialogHook("CHATHEDRAL56SQ04_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("CHATHEDRAL56SQ04_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHATHEDRAL56_SQ02_select01", "CHATHEDRAL56_SQ02", "I will bring it if you see it", "I'm busy"))
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

		await dialog.Msg("CHATHEDRAL56_SQ02_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

