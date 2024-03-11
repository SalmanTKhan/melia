//--- Melia Script -----------------------------------------------------------
// Negotiation (2)
//--- Description -----------------------------------------------------------
// Quest to Trace Rexipher.
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

[QuestScript(9002)]
public class Quest9002Script : QuestScript
{
	protected override void Load()
	{
		SetId(9002);
		SetName("Negotiation (2)");
		SetDescription("Trace Rexipher");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS31_REXITHER2_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(78));
		AddPrerequisite(new CompletedPrerequisite("ROKAS31_PACT_END"));

		AddObjective("kill0", "Kill 1 Cactusvel", new KillObjective(1, MonsterId.Boss_Cactusvel));

		AddReward(new ExpReward(640130, 640130));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 68));
		AddReward(new ItemReward("Vis", 1482));

		AddDialogHook("ROKAS31_REXITHER2", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS31_ODEL2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS31_REXITHER2_select01", "ROKAS31_REXITHER2"))
		{
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("ROKAS31_REXITHER2_dlg2");
		dialog.UnHideNPC("ROKAS31_REXITHER3");
		dialog.UnHideNPC("ROKAS31_ODEL2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

