//--- Melia Script -----------------------------------------------------------
// Goddess Gabija (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Grita at Mage Tower 1F.
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

[QuestScript(8473)]
public class Quest8473Script : QuestScript
{
	protected override void Load()
	{
		SetId(8473);
		SetName("Goddess Gabija (3)");
		SetDescription("Talk to Grita at Mage Tower 1F");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FTOWER41_MQ_01_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(113));
		AddPrerequisite(new CompletedPrerequisite("TO_THE_TOWER_02"));

		AddObjective("kill0", "Kill 6 Rubblem(s)", new KillObjective(6, MonsterId.Rubblem));

		AddReward(new ExpReward(690268, 690268));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 5));
		AddReward(new ItemReward("Vis", 2712));

		AddDialogHook("FTOWER41_GRITA_01", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER41_G_AI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FTOWER41_MQ_01_01", "FTOWER41_MQ_01", "Let's go start a fire.", "I'm not ready yet"))
		{
			case 1:
				dialog.HideNPC("FTOWER41_GRITA_01");
				await Task.Delay(500);
				// Func/FTOWER41_MQ_01_RUNNPC;
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

		await dialog.Msg("FTOWER41_MQ_01_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FTOWER41_MQ_02");
	}
}

