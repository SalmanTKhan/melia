//--- Melia Script -----------------------------------------------------------
// The Teeth of Revenge (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Audra.
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

[QuestScript(60005)]
public class Quest60005Script : QuestScript
{
	protected override void Load()
	{
		SetId(60005);
		SetName("The Teeth of Revenge (3)");
		SetDescription("Talk to Kupole Audra");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "VPRISON511_MQ_04_TRACK", 6000);

		AddPrerequisite(new LevelPrerequisite(151));
		AddPrerequisite(new CompletedPrerequisite("VPRISON511_MQ_03"));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 8));
		AddReward(new ItemReward("Vis", 4379));

		AddDialogHook("VPRISON511_MQ_AUDRA", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON511_MQ_ZYDRONE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("VPRISON511_MQ_04_01", "VPRISON511_MQ_04", "I will try", "About the Kupoles", "Tell her to wait a bit"))
		{
			case 1:
				await dialog.Msg("VPRISON511_MQ_04_AG");
				// Func/VPRISON511_MQ_04_HAUBERK_01;
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
			case 2:
				await dialog.Msg("VPRISON511_MQ_04_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("VPRISON511_MQ_04_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

