//--- Melia Script -----------------------------------------------------------
// Goddess Gabija (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Grita.
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

[QuestScript(8474)]
public class Quest8474Script : QuestScript
{
	protected override void Load()
	{
		SetId(8474);
		SetName("Goddess Gabija (4)");
		SetDescription("Talk to Grita");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FTOWER41_MQ_02_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(113));
		AddPrerequisite(new CompletedPrerequisite("FTOWER41_MQ_01"));

		AddObjective("kill0", "Kill 6 Phyracon(s)", new KillObjective(6, MonsterId.Flight_Hope));
		AddObjective("kill1", "Kill 8 Drake(s)", new KillObjective(8, MonsterId.Fire_Dragon));

		AddReward(new ExpReward(690268, 690268));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 5));
		AddReward(new ItemReward("Vis", 2712));

		AddDialogHook("FTOWER41_G_AI", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER41_G_AI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FTOWER41_MQ_02_01", "FTOWER41_MQ_02", "Move to the Magic Transport Field.", "Let's find a safer way. "))
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

		await dialog.Msg("FTOWER41_MQ_02_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FTOWER41_MQ_03");
	}
}

