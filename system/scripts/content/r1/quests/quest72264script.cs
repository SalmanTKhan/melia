//--- Melia Script -----------------------------------------------------------
// Dusk and Dawn (5)
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

[QuestScript(72264)]
public class Quest72264Script : QuestScript
{
	protected override void Load()
	{
		SetId(72264);
		SetName("Dusk and Dawn (5)");
		SetDescription("Talk to Neringa");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "EP12_FINALE_05_TRACK", "boss_giltine");

		AddPrerequisite(new LevelPrerequisite(446));
		AddPrerequisite(new CompletedPrerequisite("EP12_FINALE_04"));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 117));
		AddReward(new ItemReward("Premium_RankReset_14d", 1));

		AddDialogHook("EP12_MAINSTREAM_NERINGA", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_FINALE_RAIMA02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP12_FINALE_05_DLG01", "EP12_FINALE_05"))
		{
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("EP12_FINALE_05_DLG09");
		// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

