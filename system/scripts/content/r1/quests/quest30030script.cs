//--- Melia Script -----------------------------------------------------------
// What's Bad About Being Careful (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Jane's Spirit.
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

[QuestScript(30030)]
public class Quest30030Script : QuestScript
{
	protected override void Load()
	{
		SetId(30030);
		SetName("What's Bad About Being Careful (2)");
		SetDescription("Talk to Jane's Spirit");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CATACOMB_02_SQ_07_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(197));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_02_SQ_06"));

		AddObjective("kill0", "Kill 1 Archon", new KillObjective(1, MonsterId.Boss_Archon_Q3));

		AddReward(new ExpReward(713829, 713829));
		AddReward(new ItemReward("expCard10", 5));
		AddReward(new ItemReward("Vis", 6107));

		AddDialogHook("CATACOMB_02_NPC_01", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_02_NPC_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATACOMB_02_SQ_07_select", "CATACOMB_02_SQ_07", "All prepared", "I'm not ready yet"))
		{
			case 1:
				await dialog.Msg("CATACOMB_02_SQ_07_agree");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("CATACOMB_02_SQ_07_succ");
		ZoneServer.Instance.World.FindNPC("CATACOMB_02_NPC_01")?.PlayEffectLocal(character.Connection, "F_light003_blue", 0.5f, "MID");
		dialog.HideNPC("CATACOMB_02_NPC_01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

