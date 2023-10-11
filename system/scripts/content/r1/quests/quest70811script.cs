//--- Melia Script -----------------------------------------------------------
// Beast's End(2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Vilhelmas.
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

[QuestScript(70811)]
public class Quest70811Script : QuestScript
{
	protected override void Load()
	{
		SetId(70811);
		SetName("Beast's End(2)");
		SetDescription("Talk to Vilhelmas");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "WHITETREES23_1_SQ12_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(316));
		AddPrerequisite(new CompletedPrerequisite("WHITETREES23_1_SQ11"));

		AddObjective("kill0", "Kill 1 White Glutton", new KillObjective(1, MonsterId.Boss_Glutton_Q2));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));
		AddReward(new ItemReward("Vis", 145360));

		AddDialogHook("WHITETREES231_SQ_11_1", "BeforeStart", BeforeStart);
		AddDialogHook("WHITETREES231_SQ_11_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WHITETREES231_SQ_12_start", "WHITETREES23_1_SQ12"))
		{
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("WHITETREES231_SQ_12_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

