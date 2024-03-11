//--- Melia Script -----------------------------------------------------------
// For the greater good
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

[QuestScript(70841)]
public class Quest70841Script : QuestScript
{
	protected override void Load()
	{
		SetId(70841);
		SetName("For the greater good");
		SetDescription("Talk to Indraja");

		AddPrerequisite(new LevelPrerequisite(323));
		AddPrerequisite(new CompletedPrerequisite("WHITETREES23_3_SQ01"));

		AddObjective("kill0", "Kill 12 Kugheri Zeuni(s) or Kugheri Zabbi(s)", new KillObjective(12, 58552, 58551));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15181));

		AddDialogHook("WHITETREES233_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("WHITETREES233_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WHITETREES233_SQ_02_start", "WHITETREES23_3_SQ02", "Sure, I'll help", "About General Lhamin's Orders", "Say that you feel a bit overwhelmed"))
		{
			case 1:
				await dialog.Msg("WHITETREES233_SQ_02_agree");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("WHITETREES233_SQ_02_select");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("WHITETREES233_SQ_02_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

