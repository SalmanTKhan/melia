//--- Melia Script -----------------------------------------------------------
// Incident on Triple-Layerd Castle Wall (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Jore.
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

[QuestScript(30252)]
public class Quest30252Script : QuestScript
{
	protected override void Load()
	{
		SetId(30252);
		SetName("Incident on Triple-Layerd Castle Wall (2)");
		SetDescription("Talk to Kupole Jore");

		AddPrerequisite(new LevelPrerequisite(285));
		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_1_SQ_9"));

		AddReward(new ExpReward(4840696, 4840696));
		AddReward(new ItemReward("expCard13", 4));
		AddReward(new ItemReward("Vis", 11970));

		AddDialogHook("CASTLE_20_3_SQ_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE_20_3_SQ_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE_20_1_SQ_10_select", "CASTLE_20_1_SQ_10", "All the clues are here. It's deduction time.", "I haven't got a faintest idea yet."))
		{
			case 1:
				await dialog.Msg("CASTLE_20_1_SQ_10_agree");
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

		await dialog.Msg("CASTLE_20_1_SQ_10_succ");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You have survived a formidable experience!{nl}Speak with the Wings of Vaivora NPC to record your experience and collect your reward!");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

