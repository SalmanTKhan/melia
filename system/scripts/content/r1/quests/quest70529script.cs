//--- Melia Script -----------------------------------------------------------
// There is still not enough time
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Barry.
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

[QuestScript(70529)]
public class Quest70529Script : QuestScript
{
	protected override void Load()
	{
		SetId(70529);
		SetName("There is still not enough time");
		SetDescription("Talk to Pilgrim Barry");

		AddPrerequisite(new LevelPrerequisite(261));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_2_SQ09"));

		AddObjective("kill0", "Kill 20 Red Spion(s) or Red Spion Archer(s) or Green Tini Magician(s) or Red Guardian Spider(s)", new KillObjective(20, 57909, 57911, 57905, 57990));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 1));
		AddReward(new ItemReward("Vis", 10701));

		AddDialogHook("PILGRIM412_SQ_04_4", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM412_SQ_04_4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM412_SQ_10_start1", "PILGRIM41_2_SQ10", "Say that you will solve the problem", "Say that you do not have time for this"))
		{
			case 1:
				await dialog.Msg("PILGRIM412_SQ_10_prog");
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

		await dialog.Msg("PILGRIM412_SQ_10_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

