//--- Melia Script -----------------------------------------------------------
// Holy Goddess Statue
//--- Description -----------------------------------------------------------
// Quest to Pray in front of the Goddess Statue near the grave of the saint.
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

[QuestScript(19750)]
public class Quest19750Script : QuestScript
{
	protected override void Load()
	{
		SetId(19750);
		SetName("Holy Goddess Statue");
		SetDescription("Pray in front of the Goddess Statue near the grave of the saint");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PILGRIM51_SQ_3_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(129));

		AddObjective("kill0", "Kill 1 Sparnashorn", new KillObjective(1, MonsterId.Boss_Sparnashorn_Q2));

		AddReward(new ExpReward(542808, 542808));
		AddReward(new ItemReward("expCard7", 5));
		AddReward(new ItemReward("Vis", 3225));

		AddDialogHook("PILGRIM51_FGOD01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}
}

