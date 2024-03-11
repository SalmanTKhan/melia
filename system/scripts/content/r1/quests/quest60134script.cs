//--- Melia Script -----------------------------------------------------------
// To Expel
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Draznie.
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

[QuestScript(60134)]
public class Quest60134Script : QuestScript
{
	protected override void Load()
	{
		SetId(60134);
		SetName("To Expel");
		SetDescription("Talk with Priest Draznie");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 7 Bat(s) or Blue Vubbe Archer(s) or Blue Vubbe Thief(s) or Wendigo Escapee(s)", new KillObjective(7, 58096, 58092, 11124, 58111));

		AddReward(new ExpReward(5372, 5372));
		AddReward(new ItemReward("expCard2", 2));
		AddReward(new ItemReward("Vis", 294));

		AddDialogHook("PRISON622_DRAZUNIE", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON622_DRAZUNIE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON622_SQ_03_01", "PRISON622_SQ_03", "I'll take care of it", "That looks dangerous too"))
		{
			case 1:
				await dialog.Msg("PRISON622_SQ_03_02");
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

