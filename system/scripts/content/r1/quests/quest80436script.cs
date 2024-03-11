//--- Melia Script -----------------------------------------------------------
// Swore to Protect (10)
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

[QuestScript(80436)]
public class Quest80436Script : QuestScript
{
	protected override void Load()
	{
		SetId(80436);
		SetName("Swore to Protect (10)");
		SetDescription("Talk to Goddess Medeina");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "F_MAPLE_24_2_MQ_10_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(415));
		AddPrerequisite(new CompletedPrerequisite("F_MAPLE_24_2_MQ_09"));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 23655));

		AddDialogHook("F_MAPLE_242_MQ_MEDEINA_NPC2", "BeforeStart", BeforeStart);
		AddDialogHook("F_MAPLE_242_MQ_MEDEINA_NPC2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_MAPLE_24_2_MQ_10_ST", "F_MAPLE_24_2_MQ_10", "Alright", "I can't just leave you here."))
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

		await dialog.Msg("F_MAPLE_24_2_MQ_10_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

