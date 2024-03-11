//--- Melia Script -----------------------------------------------------------
// Divide and rule (1)
//--- Description -----------------------------------------------------------
// Quest to Find a suitable place to lure demons.
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

[QuestScript(92021)]
public class Quest92021Script : QuestScript
{
	protected override void Load()
	{
		SetId(92021);
		SetName("Divide and rule (1)");
		SetDescription("Find a suitable place to lure demons");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP13_F_SIAULIAI_4_MQ04_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(456));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_4_MQ_03"));

		AddReward(new ItemReward("expCard18", 11));
		AddReward(new ItemReward("Vis", 28272));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 33));

		AddDialogHook("EP13_GODDESS_LADA_ISA", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_GODDESS_LADA_ISA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_F_SIAULIAI_4_MQ_04_DLG1", "EP13_F_SIAULIAI_4_MQ_04", "I'll try to find it.", "Please wait for a bit"))
		{
			case 1:
				dialog.UnHideNPC("EP13_F_SIAULIAI_4_MQ04_WAY01");
				dialog.UnHideNPC("EP13_F_SIAULIAI_4_MQ04_WAY02");
				dialog.UnHideNPC("EP13_F_SIAULIAI_4_MQ04_WAY03");
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

		await dialog.Msg("EP13_F_SIAULIAI_4_MQ_04_DLG3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

