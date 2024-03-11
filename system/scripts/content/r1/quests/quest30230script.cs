//--- Melia Script -----------------------------------------------------------
// Preserve the Evidence of the Inner Wall
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

[QuestScript(30230)]
public class Quest30230Script : QuestScript
{
	protected override void Load()
	{
		SetId(30230);
		SetName("Preserve the Evidence of the Inner Wall");
		SetDescription("Talk to Kupole Jore");

		AddPrerequisite(new LevelPrerequisite(279));
		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_3_SQ_11"));

		AddObjective("kill0", "Kill 10 Akhlass Dame(s) or Akhlass Tikke(s) or Akhlass Beorn(s)", new KillObjective(10, 58604, 58605, 58606));

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

		switch (await dialog.Select("CASTLE_20_3_SQ_12_select", "CASTLE_20_3_SQ_12", "I'll defeat the monsters.", "There is no way."))
		{
			case 1:
				await dialog.Msg("CASTLE_20_3_SQ_12_agree");
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

		await dialog.Msg("CASTLE_20_3_SQ_12_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

