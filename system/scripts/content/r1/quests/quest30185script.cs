//--- Melia Script -----------------------------------------------------------
// Unexpected Situation(2)
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

[QuestScript(30185)]
public class Quest30185Script : QuestScript
{
	protected override void Load()
	{
		SetId(30185);
		SetName("Unexpected Situation(2)");
		SetDescription("Talk to Zanas' Soul");
		SetTrack(QuestStatus.Success, QuestStatus.Success, "PRISON_82_MQ_2_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(272));
		AddPrerequisite(new CompletedPrerequisite("PRISON_82_MQ_1"));

		AddObjective("collect0", "Collect 7 Observational Detector Component(s)", new CollectItemObjective("PRISON_82_MQ_2_ITEM", 7));
		AddDrop("PRISON_82_MQ_2_ITEM", 10f, 57881, 57883, 57871);

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 31));
		AddReward(new ItemReward("Vis", 11152));

		AddDialogHook("PRISON_82_NPC_2", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON_82_OBJ_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON_82_MQ_2_select", "PRISON_82_MQ_2", "Say that you will attempt to repair the Observational Detector", "Say that it is already useless"))
		{
			case 1:
				await dialog.Msg("PRISON_82_MQ_2_agree");
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

