//--- Melia Script -----------------------------------------------------------
// Altar of Vilna Forest (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Lamar.
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

[QuestScript(16240)]
public class Quest16240Script : QuestScript
{
	protected override void Load()
	{
		SetId(16240);
		SetName("Altar of Vilna Forest (2)");
		SetDescription("Talk with Lamar");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SIAULIAI_46_3_MQ_05_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(163));
		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_46_3_MQ_04"));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 44010));

		AddDialogHook("SIAULIAI_46_3_MQ05_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_46_3_MQ05_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_46_3_MQ_05_select", "SIAULIAI_46_3_MQ_05", "Better meet the priest", "Not really my problem"))
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
}

