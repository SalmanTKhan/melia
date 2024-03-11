//--- Melia Script -----------------------------------------------------------
// Creating a Quiet Environment
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Jones.
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

[QuestScript(70146)]
public class Quest70146Script : QuestScript
{
	protected override void Load()
	{
		SetId(70146);
		SetName("Creating a Quiet Environment");
		SetDescription("Talk to Monk Jones");

		AddPrerequisite(new LevelPrerequisite(179));

		AddObjective("kill0", "Kill 15 Liverwort(s)", new KillObjective(15, MonsterId.Hepatica_Green));
		AddObjective("kill1", "Kill 15 Stonacon(s)", new KillObjective(15, MonsterId.Stonacorn));

		AddReward(new ExpReward(1256004, 1256004));
		AddReward(new ItemReward("expCard9", 4));
		AddReward(new ItemReward("Vis", 5370));

		AddDialogHook("THORN393_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("THORN393_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN39_3_SQ_01_1", "THORN39_3_SQ01", "I will defeat the monsters so don't worry", "It looks safe"))
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

		await dialog.Msg("THORN39_3_SQ_01_4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

