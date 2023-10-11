//--- Melia Script -----------------------------------------------------------
// Sarma's Vain Dreams
//--- Description -----------------------------------------------------------
// Quest to Talk to Researcher Sireah.
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

[QuestScript(30215)]
public class Quest30215Script : QuestScript
{
	protected override void Load()
	{
		SetId(30215);
		SetName("Sarma's Vain Dreams");
		SetDescription("Talk to Researcher Sireah");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ORCHARD_34_3_SQ_11_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(223));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_34_3_SQ_10"));

		AddObjective("kill0", "Kill 1 Kurmis", new KillObjective(1, MonsterId.Boss_Kurmis));

		AddReward(new ExpReward(3246138, 3246138));
		AddReward(new ItemReward("expCard11", 2));
		AddReward(new ItemReward("Vis", 88308));

		AddDialogHook("ORCHARD_34_3_SQ_NPC_3", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD_34_3_SQ_NPC_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORCHARD_34_3_SQ_11_select", "ORCHARD_34_3_SQ_11", "Say that you will follow Sarma", "Say that you do not wish to pursue Sarma since you do not know what he'll do"))
		{
			case 1:
				await dialog.Msg("ORCHARD_34_3_SQ_11_agree");
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

		await dialog.Msg("ORCHARD_34_3_SQ_11_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

