//--- Melia Script -----------------------------------------------------------
// Talk to the Battle Commander (1)
//--- Description -----------------------------------------------------------
// Quest to Notify the Battle Commander of the order to assemble.
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

[QuestScript(1020)]
public class Quest1020Script : QuestScript
{
	protected override void Load()
	{
		SetId(1020);
		SetName("Talk to the Battle Commander (1)");
		SetDescription("Notify the Battle Commander of the order to assemble");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SIAUL_WEST_SOLDIER3_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(3));
		AddPrerequisite(new CompletedPrerequisite("TUTO_SKILL_RUN"));

		AddObjective("kill0", "Kill 8 Hanaming(s)", new KillObjective(8, 400941));

		AddReward(new ExpReward(1000, 1000));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 6));
		AddReward(new ItemReward("Vis", 39));

		AddDialogHook("SIAUL_WEST_SOL3", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAUL_WEST_SOLDIER3_dlg1", "SIAUL_WEST_SOLDIER3", "I'll help out with your missions", "About the monsters", "I'll wait then"))
		{
			case 1:
				await dialog.Msg("SIAUL_WEST_SOLDIER3_dlg2");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
			case 2:
				await dialog.Msg("SIAUL_WEST_SOLDIER3_add");
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("SIAUL_WEST_HAMING_LEAF");
	}
}

