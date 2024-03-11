//--- Melia Script -----------------------------------------------------------
// The Meaning of Inner Wall District 8
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

[QuestScript(30229)]
public class Quest30229Script : QuestScript
{
	protected override void Load()
	{
		SetId(30229);
		SetName("The Meaning of Inner Wall District 8");
		SetDescription("Talk to Kupole Jore");

		AddPrerequisite(new LevelPrerequisite(279));
		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_3_SQ_10"));
		AddPrerequisite(new ItemPrerequisite("CASTLE_20_3_SQ_3_ITEM_1", -100), new ItemPrerequisite("CASTLE_20_3_SQ_3_ITEM_2", -100));

		AddReward(new ExpReward(4840696, 4840696));
		AddReward(new ItemReward("expCard13", 4));
		AddReward(new ItemReward("Vis", 11439));

		AddDialogHook("CASTLE_20_3_SQ_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE_20_3_SQ_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE_20_3_SQ_11_select", "CASTLE_20_3_SQ_11", "Hmm, let's see.", "I can't be bothered, frankly."))
		{
			case 1:
				await dialog.Msg("CASTLE_20_3_SQ_11_agree");
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

		await dialog.Msg("CASTLE_20_3_SQ_11_succ");
		dialog.UnHideNPC("CASTLE_20_2_NPC_1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

