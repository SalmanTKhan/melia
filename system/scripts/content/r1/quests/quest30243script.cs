//--- Melia Script -----------------------------------------------------------
// Operation Outter Wall Core Retrieval(1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Milda.
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

[QuestScript(30243)]
public class Quest30243Script : QuestScript
{
	protected override void Load()
	{
		SetId(30243);
		SetName("Operation Outter Wall Core Retrieval(1)");
		SetDescription("Talk to Kupole Milda");

		AddPrerequisite(new LevelPrerequisite(285));
		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_2_SQ_12"));

		AddObjective("kill0", "Kill 8 Akhlass Petal(s) or Akhlass Steel(s) or Akhlacia(s) or Akhlass Countess(s)", new KillObjective(8, 58609, 58610, 58611, 58613));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11970));

		AddDialogHook("CASTLE_20_1_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE_20_1_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE_20_1_SQ_1_select", "CASTLE_20_1_SQ_1", "Monsters look awfully aggressive.", "Meh, they look mostly harmless."))
		{
			case 1:
				await dialog.Msg("CASTLE_20_1_SQ_1_agree");
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

		await dialog.Msg("CASTLE_20_1_SQ_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

