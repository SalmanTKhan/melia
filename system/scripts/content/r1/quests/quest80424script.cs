//--- Melia Script -----------------------------------------------------------
// All Kinds of Preparations
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Medeina.
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

[QuestScript(80424)]
public class Quest80424Script : QuestScript
{
	protected override void Load()
	{
		SetId(80424);
		SetName("All Kinds of Preparations");
		SetDescription("Talk to Goddess Medeina");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_MAPLE_24_1_MQ_04_2_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(411));
		AddPrerequisite(new CompletedPrerequisite("F_MAPLE_24_1_MQ_03"), new CompletedPrerequisite("F_MAPLE_24_1_MQ_04"));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 23427));

		AddDialogHook("F_MAPLE_241_MQ_MEDEINA_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_MAPLE_241_MQ_MEDEINA_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_MAPLE_24_1_MQ_04_2_ST", "F_MAPLE_24_1_MQ_04_2", "Leave it to me.", "I'm afraid I'll have to pass."))
		{
			case 1:
				await dialog.Msg("F_MAPLE_24_1_MQ_04_2_AFST");
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

		await dialog.Msg("F_MAPLE_24_1_MQ_04_2_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

