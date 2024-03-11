//--- Melia Script -----------------------------------------------------------
// The Goddess' Hideout (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Ilona.
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

[QuestScript(80419)]
public class Quest80419Script : QuestScript
{
	protected override void Load()
	{
		SetId(80419);
		SetName("The Goddess' Hideout (1)");
		SetDescription("Talk to Kupole Ilona");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_MAPLE_24_1_MQ_01_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(411));
		AddPrerequisite(new CompletedPrerequisite("F_MAPLE_24_3_MQ_11"));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 23427));

		AddDialogHook("F_MAPLE_241_MQ_01_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_MAPLE_241_MQ_02_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_MAPLE_24_1_MQ_01_ST", "F_MAPLE_24_1_MQ_01", "Alright", "That's not something I want to do."))
		{
			case 1:
				// Func/SCR_F_MAPLE_241_MQ_01_RUNNPC;
				dialog.HideNPC("F_MAPLE_241_MQ_01_NPC");
				await dialog.Msg("F_MAPLE_24_1_MQ_01_AFST");
				// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
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

		await dialog.Msg("F_MAPLE_24_1_MQ_01_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

