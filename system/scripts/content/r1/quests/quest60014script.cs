//--- Melia Script -----------------------------------------------------------
// The Evening Star Key (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Zydrone.
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

[QuestScript(60014)]
public class Quest60014Script : QuestScript
{
	protected override void Load()
	{
		SetId(60014);
		SetName("The Evening Star Key (2)");
		SetDescription("Talk to Kupole Zydrone");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "VPRISON514_MQ_03_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(157));
		AddPrerequisite(new CompletedPrerequisite("VPRISON514_MQ_02"));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 9));
		AddReward(new ItemReward("VPRISON514_MQ_04_ITEM", 1));
		AddReward(new ItemReward("Vis", 4553));

		AddDialogHook("VPRISON514_MQ_ZYDRONE", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON514_MQ_ZYDRONE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("VPRISON514_MQ_03_01", "VPRISON514_MQ_03", "I will make sure to protect it", "Tell her that we should prepare little more"))
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

		await dialog.Msg("VPRISON514_MQ_03_03");
		// Func/VPRISON514_MQ_03_HAUBERK_01;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

