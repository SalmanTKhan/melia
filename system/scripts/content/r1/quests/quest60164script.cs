//--- Melia Script -----------------------------------------------------------
// Spirit-carrying Monster
//--- Description -----------------------------------------------------------
// Quest to Conversation with gloomy owl image.
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

[QuestScript(60164)]
public class Quest60164Script : QuestScript
{
	protected override void Load()
	{
		SetId(60164);
		SetName("Spirit-carrying Monster");
		SetDescription("Conversation with gloomy owl image");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 7 Digo(s) or Belstool(s) or Blue Kodomor(s) or Eldigo(s) or Blue Beeteros(s) or Red Apparition(s) or Blue Truffle(s)", new KillObjective(7, 57525, 57680, 57807, 57448, 58204, 58208, 58205));

		AddReward(new ExpReward(8442, 8442));
		AddReward(new ItemReward("expCard3", 1));
		AddReward(new ItemReward("Vis", 1026));

		AddDialogHook("KATYN10_RP_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN10_RP_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN10_RP_1_1", "KATYN10_RP_1", "Alright, I'll help you", "I'm sorry"))
		{
			case 1:
				// Func/KATYN10_RP_1_SCP_RUN_1;
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

