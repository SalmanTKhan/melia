//--- Melia Script -----------------------------------------------------------
// The Goddess' Sacrifice (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Dalia.
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

[QuestScript(80170)]
public class Quest80170Script : QuestScript
{
	protected override void Load()
	{
		SetId(80170);
		SetName("The Goddess' Sacrifice (1)");
		SetDescription("Talk to Goddess Dalia");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "LIMESTONE_52_5_MQ_9_TRACK", "m_boss_scenario");

		AddPrerequisite(new LevelPrerequisite(301));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_5_MQ_8"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 4));

		AddDialogHook("LIMESTONECAVE_52_5_DALIA", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONECAVE_52_5_MEDENA_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_5_MQ_9_start", "LIMESTONE_52_5_MQ_9", "Use the Divine Orb.", "Don't use the Divine Orb."))
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

		dialog.HideNPC("LIMESTONE_52_5_MQ_6_ANTIEVIL_2");
		dialog.UnHideNPC("LIMESTONE_52_5_MQ_6_ANTIEVIL_1");
		await dialog.Msg("LIMESTONE_52_5_MQ_9_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}
