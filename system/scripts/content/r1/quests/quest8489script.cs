//--- Melia Script -----------------------------------------------------------
// Mage Tower 4th Floor (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Grita.
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

[QuestScript(8489)]
public class Quest8489Script : QuestScript
{
	protected override void Load()
	{
		SetId(8489);
		SetName("Mage Tower 4th Floor (2)");
		SetDescription("Talk to Grita");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FTOWER44_MQ_02_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(123));
		AddPrerequisite(new CompletedPrerequisite("FTOWER44_MQ_01"));

		AddObjective("kill0", "Kill 20 Minivern(s)", new KillObjective(20, MonsterId.Minivern));

		AddReward(new ExpReward(690268, 690268));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 5));
		AddReward(new ItemReward("Vis", 3075));

		AddDialogHook("FTOWER44_G_AI", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER44_G_AI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FTOWER44_MQ_02_01", "FTOWER44_MQ_02", "I'll find the Magic Stabilizing Device", "Let's just go up"))
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

		await dialog.Msg("FTOWER44_MQ_02_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FTOWER44_MQ_03");
	}
}

