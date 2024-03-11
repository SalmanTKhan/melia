//--- Melia Script -----------------------------------------------------------
// The Altars of Kadumel Cliff (1)
//--- Description -----------------------------------------------------------
// Quest to Investigate the Altar.
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

[QuestScript(50182)]
public class Quest50182Script : QuestScript
{
	protected override void Load()
	{
		SetId(50182);
		SetName("The Altars of Kadumel Cliff (1)");
		SetDescription("Investigate the Altar");

		AddPrerequisite(new LevelPrerequisite(250));

		AddObjective("kill0", "Kill 10 White Wendigo Searcher(s) or Blue Tini Archer(s) or Blue Hohen Gulak(s)", new KillObjective(10, 57873, 57906, 57977));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 10000));

		AddDialogHook("TABLE73_SUBQ_ALTAR1", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE73_SUBQ_ALTAR1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "The altar's power has been restored.");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

