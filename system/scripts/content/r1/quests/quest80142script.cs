//--- Melia Script -----------------------------------------------------------
// Kupole in the Darkness (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Serija.
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

[QuestScript(80142)]
public class Quest80142Script : QuestScript
{
	protected override void Load()
	{
		SetId(80142);
		SetName("Kupole in the Darkness (2)");
		SetDescription("Talk to Kupole Serija");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "LIMESTONE_52_3_MQ_6_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(294));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_3_MQ_5"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 12348));

		AddDialogHook("LIMESTONECAVE_52_3_SERIJA_3", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONECAVE_52_3_SERIJA_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_3_MQ_6_start", "LIMESTONE_52_3_MQ_6", "I'll lend my strength to you", "I don't think that's going to work."))
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

		// Func/LIMESTONECAVE_HIDE_FUNC_RUN;
		dialog.UnHideNPC("LIMESTONECAVE_52_3_MEDENA_AI");
		await dialog.Msg("LIMESTONE_52_3_MQ_6_succ");
		await dialog.Msg("LIMESTONE_52_3_MQ_6_succ_2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

