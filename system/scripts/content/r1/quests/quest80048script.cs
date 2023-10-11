//--- Melia Script -----------------------------------------------------------
// Temple Rebuilding Preparation (1)
//--- Description -----------------------------------------------------------
// Quest to Speak with the Village Priest.
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

[QuestScript(80048)]
public class Quest80048Script : QuestScript
{
	protected override void Load()
	{
		SetId(80048);
		SetName("Temple Rebuilding Preparation (1)");
		SetDescription("Speak with the Village Priest");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_324_MQ_07"));

		AddObjective("kill0", "Kill 12 Vikaras Mage(s)", new KillObjective(12, MonsterId.Sec_Wolf_Statue_Mage));

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 2400));

		AddDialogHook("ORCHARD324_PRIEST", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD324_PRIEST", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORCHARD_324_SQ_01_start", "ORCHARD_324_SQ_01", "Alright, I'll help you", "I don't have time for that"))
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

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ORCHARD_324_SQ_02");
	}
}

