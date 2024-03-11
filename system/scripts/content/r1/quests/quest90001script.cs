//--- Melia Script -----------------------------------------------------------
// The Corrupted Lake (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Elder Aloizard.
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

[QuestScript(90001)]
public class Quest90001Script : QuestScript
{
	protected override void Load()
	{
		SetId(90001);
		SetName("The Corrupted Lake (1)");
		SetDescription("Talk to Elder Aloizard");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 8 Merog Stinger(s) or Merog Shaman(s) or Rajatadpole(s)", new KillObjective(8, 58106, 58105, 41308));

		AddReward(new ExpReward(245710, 245710));
		AddReward(new ItemReward("expCard5", 2));
		AddReward(new ItemReward("Vis", 1235));
		AddReward(new ItemReward("Drug_SP2_Q", 30));

		AddDialogHook("3CMLAKE_83_OLDMAN1", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_83_OLDMAN1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("3CMLAKE_83_MQ_01_DLG_01", "F_3CMLAKE_83_MQ_01", "I'll help you", "I don't think I'm skilled enough for that"))
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


		return HookResult.Break;
	}
}

