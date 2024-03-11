//--- Melia Script -----------------------------------------------------------
// Lost in the Forest (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Settler Izna.
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

[QuestScript(60079)]
public class Quest60079Script : QuestScript
{
	protected override void Load()
	{
		SetId(60079);
		SetName("Lost in the Forest (1)");
		SetDescription("Talk with Settler Izna");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(1000, 1000));
		AddReward(new ItemReward("expCard1", 2));
		AddReward(new ItemReward("Vis", 13));

		AddDialogHook("SIAULIAI16_IZNA", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI16_IZNA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAU16_SQ_03_01", "SIAU16_SQ_03", "Sure, I'll help", "I'm busy"))
		{
			case 1:
				dialog.UnHideNPC("SIAU16_SQ_03_NPC");
				dialog.ShowHelp("SIAU16_SQ_03");
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

