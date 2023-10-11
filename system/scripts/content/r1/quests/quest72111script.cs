//--- Melia Script -----------------------------------------------------------
// For Fluid Investigation
//--- Description -----------------------------------------------------------
// Quest to Talk to Skirgaila.
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

[QuestScript(72111)]
public class Quest72111Script : QuestScript
{
	protected override void Load()
	{
		SetId(72111);
		SetName("For Fluid Investigation");
		SetDescription("Talk to Skirgaila");

		AddPrerequisite(new LevelPrerequisite(333));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE261_SQ11"));

		AddObjective("kill0", "Kill 20 Kindron Weilder(s) or Kindron Reilter(s) or Lavisher Mage(s) or Lavisher(s)", new KillObjective(20, 58832, 58833, 58834, 58835));

		AddReward(new ItemReward("Vis", 3130));

		AddDialogHook("3CMLAKE_SKIRGAILA", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_SKIRGAILA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("3CMLAKE261_SQ12_DLG01", "F_3CMLAKE261_SQ12", "I will help", "I have other obligations."))
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

		await dialog.Msg("3CMLAKE261_SQ12_DLG03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

