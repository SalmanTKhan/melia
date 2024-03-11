//--- Melia Script -----------------------------------------------------------
// Obtaining the Defensive Device Lever (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Commander Byle.
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

[QuestScript(72185)]
public class Quest72185Script : QuestScript
{
	protected override void Load()
	{
		SetId(72185);
		SetName("Obtaining the Defensive Device Lever (2)");
		SetDescription("Talk to Resistance Commander Byle");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "STARTOWER_89_MQ_50_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(375));
		AddPrerequisite(new CompletedPrerequisite("STARTOWER_89_MQ_40"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 19500));

		AddDialogHook("D_STARTOWER_89_RESISTANCE_LEADER_BAYL_02", "BeforeStart", BeforeStart);
		AddDialogHook("D_STARTOWER_89_MQ_50_TRIGGER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("STARTOWER_89_MQ_50_DLG1", "STARTOWER_89_MQ_50", "Alright", "I'm not ready yet."))
		{
			case 1:
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


		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("STARTOWER_89_MQ_60");
	}
}

