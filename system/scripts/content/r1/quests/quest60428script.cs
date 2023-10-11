//--- Melia Script -----------------------------------------------------------
// Time Never Stops
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

[QuestScript(60428)]
public class Quest60428Script : QuestScript
{
	protected override void Load()
	{
		SetId(60428);
		SetName("Time Never Stops");
		SetDescription("Talk to Ineta");

		AddPrerequisite(new LevelPrerequisite(401));
		AddPrerequisite(new CompletedPrerequisite("CASTLE98_MQ_7"));

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

		switch (await dialog.Select("CASTLE98_MQ_8_1", "CASTLE98_MQ_8", "Alright", "I don't really want to know."))
		{
			case 1:
				character.AddonMessage(AddonMessage.NOTICE_Dm_Scroll, "Use the Time Meter Necklace near Kedora Alliance Ineta.");
				// Func/SCR_CASTLE98_MQ_8_RESTART_GIVEITEAM;
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

		await dialog.Msg("CASTLE98_MQ_8_3");
		// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

