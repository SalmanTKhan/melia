//--- Melia Script -----------------------------------------------------------
// Pain can wait
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Barry.
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

[QuestScript(70522)]
public class Quest70522Script : QuestScript
{
	protected override void Load()
	{
		SetId(70522);
		SetName("Pain can wait");
		SetDescription("Talk to Pilgrim Barry");

		AddPrerequisite(new LevelPrerequisite(261));

		AddObjective("kill0", "Kill 18 Red Spion(s) or Red Spion Archer(s) or Green Tini Magician(s)", new KillObjective(18, 57909, 57911, 57905));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 10701));

		AddDialogHook("PILGRIM412_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM412_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM412_SQ_03_start", "PILGRIM41_2_SQ03", "Say that you understand", "Say that you are afraid of monsters as well"))
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

		await dialog.Msg("PILGRIM412_SQ_03_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

