//--- Melia Script -----------------------------------------------------------
// Say that they must not know
//--- Description -----------------------------------------------------------
// Quest to Talk to Indraja.
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

[QuestScript(70850)]
public class Quest70850Script : QuestScript
{
	protected override void Load()
	{
		SetId(70850);
		SetName("Say that they must not know");
		SetDescription("Talk to Indraja");

		AddPrerequisite(new LevelPrerequisite(323));
		AddPrerequisite(new CompletedPrerequisite("WHITETREES23_3_SQ10"));

		AddObjective("kill0", "Kill 20 Kugheri Numani(s) or Kugheri Zeuni(s) or Kugheri Zabbi(s)", new KillObjective(20, 58549, 58552, 58551));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 136629));

		AddDialogHook("WHITETREES233_SQ_08", "BeforeStart", BeforeStart);
		AddDialogHook("WHITETREES233_SQ_08", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WHITETREES233_SQ_11_start1", "WHITETREES23_3_SQ11", "Say that you will deal with them", "Say that all loose ends must be covered since you have come this far"))
		{
			case 1:
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

		await dialog.Msg("WHITETREES233_SQ_11_succ1");
		await dialog.Msg("FadeOutIN/1000");
		// Func/WHITETREES233_SUBNPC_HIDE;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

