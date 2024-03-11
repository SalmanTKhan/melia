//--- Melia Script -----------------------------------------------------------
// Root of the Divine Tree (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Austeja.
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

[QuestScript(80455)]
public class Quest80455Script : QuestScript
{
	protected override void Load()
	{
		SetId(80455);
		SetName("Root of the Divine Tree (2)");
		SetDescription("Talk to Goddess Austeja");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_CASTLE_99_MQ_02_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(431));
		AddPrerequisite(new CompletedPrerequisite("F_CASTLE_99_MQ_01"));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 16));
		AddReward(new ItemReward("Vis", 24998));

		AddDialogHook("F_CASTLE_99_MQ_01_NPC", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_CASTLE_99_MQ_02_ST", "F_CASTLE_99_MQ_02", "Alright", "Say it's pointless."))
		{
			case 1:
				await dialog.Msg("F_CASTLE_99_MQ_02_AFST");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("F_CASTLE_99_MQ_03");
	}
}

