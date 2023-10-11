//--- Melia Script -----------------------------------------------------------
// For What
//--- Description -----------------------------------------------------------
// Quest to Talk to Baron Secretary Benius.
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

[QuestScript(60179)]
public class Quest60179Script : QuestScript
{
	protected override void Load()
	{
		SetId(60179);
		SetName("For What");
		SetDescription("Talk to Baron Secretary Benius");

		AddPrerequisite(new LevelPrerequisite(86));
		AddPrerequisite(new CompletedPrerequisite("FARM47_3_SQ_100"));

		AddObjective("kill0", "Kill 9 Farm Keposeed(s) or Farm Ellum(s) or Cronewt Poisoned Needler(s) or White Operor(s)", new KillObjective(9, 57503, 57502, 57646, 57330));

		AddReward(new ExpReward(49142, 49142));
		AddReward(new ItemReward("expCard6", 2));
		AddReward(new ItemReward("Vis", 1720));

		AddDialogHook("FARM47_BENIUS", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_BENIUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM473_RP_1_1", "FARM473_RP_1", "Alright", "Ignore"))
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

		await dialog.Msg("FARM473_RP_1_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

