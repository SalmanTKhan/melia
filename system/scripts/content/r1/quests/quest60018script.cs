//--- Melia Script -----------------------------------------------------------
// Hauberk in the Maze (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Daiva.
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

[QuestScript(60018)]
public class Quest60018Script : QuestScript
{
	protected override void Load()
	{
		SetId(60018);
		SetName("Hauberk in the Maze (1)");
		SetDescription("Talk to Kupole Daiva");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "VPRISON513_MQ_01_TRACK");

		AddPrerequisite(new LevelPrerequisite(160));
		AddPrerequisite(new CompletedPrerequisite("VPRISON514_MQ_06"));

		AddObjective("kill0", "Kill 8 Hohen Ritter(s) or Hohen Orben(s)", new KillObjective(8, 57716, 57719));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 9));
		AddReward(new ItemReward("Vis", 4800));

		AddDialogHook("VPRISON513_MQ_DAIVA_01", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON513_MQ_DAIVA_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("VPRISON513_MQ_01_01_1", "VPRISON513_MQ_01", "I will chase after Hauberk", "I will prepare little more"))
		{
			case 1:
				dialog.UnHideNPC("VPRISON513_MQ_01_NPC");
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

		await dialog.Msg("VPRISON513_MQ_01_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

