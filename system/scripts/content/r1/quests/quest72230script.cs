//--- Melia Script -----------------------------------------------------------
// Detached Forces
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Adjutant Antanina.
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

[QuestScript(72230)]
public class Quest72230Script : QuestScript
{
	protected override void Load()
	{
		SetId(72230);
		SetName("Detached Forces");
		SetDescription("Talk to Resistance Adjutant Antanina");

		AddPrerequisite(new LevelPrerequisite(397));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("CASTLE95_NPC_MAIN01", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE95_NPC_MAIN01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE95_MAIN01_01", "CASTLE95_MAIN01", "Just give some time to think.", "Oh my, would you look at the time!"))
		{
			case 1:
				await dialog.Msg("CASTLE95_MAIN01_02");
				// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
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

		await dialog.Msg("CASTLE95_MAIN01_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

