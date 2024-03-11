//--- Melia Script -----------------------------------------------------------
// I don't know if it will be useful
//--- Description -----------------------------------------------------------
// Quest to Talk to Vilhelmas.
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

[QuestScript(70804)]
public class Quest70804Script : QuestScript
{
	protected override void Load()
	{
		SetId(70804);
		SetName("I don't know if it will be useful");
		SetDescription("Talk to Vilhelmas");

		AddPrerequisite(new LevelPrerequisite(316));
		AddPrerequisite(new CompletedPrerequisite("WHITETREES23_1_SQ04"));

		AddObjective("kill0", "Kill 18 Kugheri Tot(s) or Kugheri Sommi(s) or Kugheri Lyoni(s)", new KillObjective(18, 58546, 58547, 58548));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14536));

		AddDialogHook("WHITETREES231_SQ_05", "BeforeStart", BeforeStart);
		AddDialogHook("WHITETREES231_SQ_05", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WHITETREES231_SQ_05_start", "WHITETREES23_1_SQ05", "Say that you are prepared to face any challenge", "Ask about the beast's identity", "Say that you do not want to be involved in anything complicated"))
		{
			case 1:
				await dialog.Msg("WHITETREES231_SQ_05_agree");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("WHITETREES231_SQ_05_select");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		character.AddonMessage(AddonMessage.SHOW_QUEST_SEL_DLG, null, this.QuestId);
		await dialog.Msg("WHITETREES231_SQ_05_succ1");
		await dialog.Msg("I am the Revelator");
		await dialog.Msg("WHITETREES231_SQ_05_succ2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

