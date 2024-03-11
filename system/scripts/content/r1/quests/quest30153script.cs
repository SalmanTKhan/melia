//--- Melia Script -----------------------------------------------------------
// Visiting Room Barrier
//--- Description -----------------------------------------------------------
// Quest to Talk to Zanas' Soul.
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

[QuestScript(30153)]
public class Quest30153Script : QuestScript
{
	protected override void Load()
	{
		SetId(30153);
		SetName("Visiting Room Barrier");
		SetDescription("Talk to Zanas' Soul");
		SetTrack(QuestStatus.Success, QuestStatus.Success, "PRISON_78_MQ_9_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(259));
		AddPrerequisite(new CompletedPrerequisite("PRISON_78_MQ_8"));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 17));

		AddDialogHook("PRISON_78_NPC_2", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON_78_MQ_9_select", "PRISON_78_MQ_9", "Ask if it isn't dangerous", "Say that you don't know what he's talking about"))
		{
			case 1:
				await dialog.Msg("PRISON_78_MQ_9_agree");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

