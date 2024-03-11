//--- Melia Script -----------------------------------------------------------
// Swore to Protect (9)
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

[QuestScript(80435)]
public class Quest80435Script : QuestScript
{
	protected override void Load()
	{
		SetId(80435);
		SetName("Swore to Protect (9)");
		SetDescription("Talk to Goddess Medeina");
		SetTrack(QuestStatus.Possible, QuestStatus.Possible, "F_MAPLE_24_2_MQ_09_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(415));
		AddPrerequisite(new CompletedPrerequisite("F_MAPLE_24_2_MQ_08"));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("F_MAPLE_242_MQ_MEDEINA_NPC1_AFTER", "BeforeStart", BeforeStart);
		AddDialogHook("F_MAPLE_242_MQ_MEDEINA_NPC2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_MAPLE_24_2_MQ_09_ST", "F_MAPLE_24_2_MQ_09", "Let's get out of here.", "We should get ready first."))
		{
			case 1:
				dialog.HideNPC("F_MAPLE_242_MQ_06_NPC1");
				dialog.HideNPC("F_MAPLE_242_MQ_06_NPC2");
				dialog.HideNPC("F_MAPLE_242_MQ_MEDEINA_NPC1_AFTER");
				dialog.UnHideNPC("F_MAPLE_242_MQ_MEDEINA_NPC2");
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

		await dialog.Msg("F_MAPLE_24_2_MQ_09_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

