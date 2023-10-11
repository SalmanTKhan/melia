//--- Melia Script -----------------------------------------------------------
// Obscure Era
//--- Description -----------------------------------------------------------
// Quest to Talk to Ineta.
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

[QuestScript(60421)]
public class Quest60421Script : QuestScript
{
	protected override void Load()
	{
		SetId(60421);
		SetName("Obscure Era");
		SetDescription("Talk to Ineta");

		AddPrerequisite(new LevelPrerequisite(404));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 23028));

		AddDialogHook("CASTLE98_MQ_INETA_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE98_MQ_INETA_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE98_MQ_1_1", "CASTLE98_MQ_1", "Calm down", "You got the wrong person, sorry."))
		{
			case 1:
				character.AddonMessage(AddonMessage.NOTICE_Dm_Scroll, "Use the Time Meter Necklace near Kedora Alliance Ineta.");
				await dialog.Msg("CASTLE98_MQ_1_1_1");
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

		await dialog.Msg("CASTLE98_MQ_1_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

