//--- Melia Script -----------------------------------------------------------
// Going Below the Shadow (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Neringa.
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

[QuestScript(60252)]
public class Quest60252Script : QuestScript
{
	protected override void Load()
	{
		SetId(60252);
		SetName("Going Below the Shadow (5)");
		SetDescription("Talk to Neringa");

		AddPrerequisite(new LevelPrerequisite(338));
		AddPrerequisite(new CompletedPrerequisite("FANTASYLIB482_MQ_4"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("FLIBRARY482_NERINGA_NPC_2", "BeforeStart", BeforeStart);
		AddDialogHook("FLIBRARY482_VIDA_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FANTASYLIB482_MQ_5_1", "FANTASYLIB482_MQ_5", "I'll think it through.", "I need to prepare"))
		{
			case 1:
				dialog.UnHideNPC("FANTASYLIB482_MQ_5_NPC");
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

		await dialog.Msg("FANTASYLIB482_MQ_5_3");
		dialog.HideNPC("FANTASYLIB482_MQ_5_NPC");
		dialog.HideNPC("FLIBRARY482_NERINGA_NPC_2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

