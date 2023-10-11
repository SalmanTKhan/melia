//--- Melia Script -----------------------------------------------------------
// Accident Prevention
//--- Description -----------------------------------------------------------
// Quest to Talk to Scalvis.
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

[QuestScript(90009)]
public class Quest90009Script : QuestScript
{
	protected override void Load()
	{
		SetId(90009);
		SetName("Accident Prevention");
		SetDescription("Talk to Scalvis");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 10 Merog Stinger(s) or Merog Shaman(s) or Rajatadpole(s)", new KillObjective(10, 58106, 58105, 41308));

		AddReward(new ExpReward(24571, 24571));
		AddReward(new ItemReward("expCard5", 1));
		AddReward(new ItemReward("Vis", 1235));

		AddDialogHook("3CMLAKE_83_PEOPLE3", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_83_PEOPLE3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("3CMLAKE_83_SQ_04_DLG_01", "F_3CMLAKE_83_SQ_04", "I can help you with that", "I have no time for that, sorry"))
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

