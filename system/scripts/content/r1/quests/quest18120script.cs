//--- Melia Script -----------------------------------------------------------
// Search for the Missing Villager
//--- Description -----------------------------------------------------------
// Quest to Talk to the Old Man.
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

[QuestScript(18120)]
public class Quest18120Script : QuestScript
{
	protected override void Load()
	{
		SetId(18120);
		SetName("Search for the Missing Villager");
		SetDescription("Talk to the Old Man");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "HUEVILLAGE_58_1_MQ03_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(36));
		AddPrerequisite(new CompletedPrerequisite("HUEVILLAGE_58_1_MQ02"));

		AddObjective("kill0", "Kill 8 Tipio(s) or Tanu(s)", new KillObjective(8, 47480, 47472));

		AddReward(new ExpReward(118188, 118188));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 31));
		AddReward(new ItemReward("Vis", 504));

		AddDialogHook("HUEVILLAGE_58_1_MQ01_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("HUEVILLAGE_58_1_MQ03_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("HUEVILLAGE_58_1_MQ03_select", "HUEVILLAGE_58_1_MQ03", "I'll look for him", "Cancel"))
		{
			case 1:
				await dialog.Msg("HUEVILLAGE_58_1_MQ03_agree");
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

		await dialog.Msg("HUEVILLAGE_58_1_MQ03_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("HUEVILLAGE_58_1_MQ04");
	}
}

