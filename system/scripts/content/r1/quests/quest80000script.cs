//--- Melia Script -----------------------------------------------------------
// Those Who Disturb the Prayers
//--- Description -----------------------------------------------------------
// Quest to Talk to Bokor Juta.
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

[QuestScript(80000)]
public class Quest80000Script : QuestScript
{
	protected override void Load()
	{
		SetId(80000);
		SetName("Those Who Disturb the Prayers");
		SetDescription("Talk to Bokor Juta");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 12 Green Fisherman(s) or Green Maggot(s) or Catacombs Leaf Bug(s) or Drapel(s)", new KillObjective(12, 400343, 58113, 58125, 57685));

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("Vis", 1330));

		AddDialogHook("CATACOMB_33_1_JUTA", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_33_1_JUTA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATACOMB_33_1_SQ_01_start", "CATACOMB_33_1_SQ_01", "Alright, I'll help you", "It's hard for me"))
		{
			case 1:
				await dialog.Msg("CATACOMB_33_1_SQ_01_agree");
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
		character.Quests.Start("CATACOMB_33_1_SQ_02");
	}
}

