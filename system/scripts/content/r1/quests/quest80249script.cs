//--- Melia Script -----------------------------------------------------------
// The Secret of the Lake (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Adjutant Bern.
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

[QuestScript(80249)]
public class Quest80249Script : QuestScript
{
	protected override void Load()
	{
		SetId(80249);
		SetName("The Secret of the Lake (4)");
		SetDescription("Talk to Resistance Adjutant Bern");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "F_3CMLAKE_85_MQ_07_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(362));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_85_MQ_06"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 18824));

		AddDialogHook("F_3CMLAKE_85_MQ_06_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_85_MQ_07_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_85_MQ_07_ST", "F_3CMLAKE_85_MQ_07", "Let's go together.", "That's not something I want to do."))
		{
			case 1:
				dialog.HideNPC("F_3CMLAKE_85_MQ_06_NPC");
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

		await dialog.Msg("F_3CMLAKE_85_MQ_07_SU");
		dialog.HideNPC("F_3CMLAKE_85_MQ_07_NPC");
		dialog.UnHideNPC("F_3CMLAKE_85_MQ_02_NPC");
		await dialog.Msg("FadeOutIN/1000");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

