//--- Melia Script -----------------------------------------------------------
// It's All Over Now
//--- Description -----------------------------------------------------------
// Quest to Talk to Farmer Darcy.
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

[QuestScript(70006)]
public class Quest70006Script : QuestScript
{
	protected override void Load()
	{
		SetId(70006);
		SetName("It's All Over Now");
		SetDescription("Talk to Farmer Darcy");

		AddPrerequisite(new LevelPrerequisite(149));

		AddObjective("kill0", "Kill 15 Orange Lizardman(s)", new KillObjective(15, MonsterId.Lizardman_Orange));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 3874));

		AddDialogHook("FARM491_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("FARM491_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM49_1_SQ_01_1", "FARM49_1_SQ01", "Ask him what's the matter and I will help", "About the Greene family farm", "Ignore and just go on your way"))
		{
			case 1:
				await dialog.Msg("FARM49_1_SQ_01_2");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FARM49_1_SQ_01_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FARM49_1_SQ_01_4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

