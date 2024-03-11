//--- Melia Script -----------------------------------------------------------
// They Hid Her (2)
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

[QuestScript(80152)]
public class Quest80152Script : QuestScript
{
	protected override void Load()
	{
		SetId(80152);
		SetName("They Hid Her (2)");
		SetDescription("Talk to Kupole Serija");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "LIMESTONE_52_4_MQ_4_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(298));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_4_MQ_3"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 4));
		AddReward(new ItemReward("Vis", 12516));

		AddDialogHook("LIMESTONECAVE_52_4_SERIJA", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONECAVE_52_4_SERIJA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_4_MQ_4_start", "LIMESTONE_52_4_MQ_4", "Alright", "I don't have the power to do that."))
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

		await dialog.Msg("LIMESTONE_52_4_MQ_4_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

