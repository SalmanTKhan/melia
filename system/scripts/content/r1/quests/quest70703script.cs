//--- Melia Script -----------------------------------------------------------
// Set up a memorial monument
//--- Description -----------------------------------------------------------
// Quest to Talk to the soul of Victoras.
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

[QuestScript(70703)]
public class Quest70703Script : QuestScript
{
	protected override void Load()
	{
		SetId(70703);
		SetName("Set up a memorial monument");
		SetDescription("Talk to the soul of Victoras");

		AddPrerequisite(new LevelPrerequisite(278));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN42_1_SQ03"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11398));

		AddDialogHook("BRACKEN421_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN421_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN421_SQ_04_start", "BRACKEN42_1_SQ04", "What needs to be done?", "I hate doing complicated tasks."))
		{
			case 1:
				await dialog.Msg("BRACKEN421_SQ_04_agree");
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

		await dialog.Msg("BRACKEN421_SQ_04_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

