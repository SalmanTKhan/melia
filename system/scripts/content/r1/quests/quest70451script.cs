//--- Melia Script -----------------------------------------------------------
// Finding Clues to the Plot
//--- Description -----------------------------------------------------------
// Quest to Talk to Revelator Yane.
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

[QuestScript(70451)]
public class Quest70451Script : QuestScript
{
	protected override void Load()
	{
		SetId(70451);
		SetName("Finding Clues to the Plot");
		SetDescription("Talk to Revelator Yane");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("CASTLE65_3_MQ09"));

		AddObjective("kill0", "Kill 24 Pag Nurse(s) or Pag Emitter(s) or Pag Doper(s)", new KillObjective(24, 58076, 58077, 58078));

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("Vis", 1680));

		AddDialogHook("CASTLE653_MQ_04_1", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE653_MQ_04_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE653_SQ_03_start", "CASTLE65_3_SQ03", "Just tell me what you need", "I'll take it from here"))
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

