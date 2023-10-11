//--- Melia Script -----------------------------------------------------------
// Stop the facilities from being destroyed
//--- Description -----------------------------------------------------------
// Quest to Read the design plan of the Royal Mausoleum.
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

[QuestScript(8385)]
public class Quest8385Script : QuestScript
{
	protected override void Load()
	{
		SetId(8385);
		SetName("Stop the facilities from being destroyed");
		SetDescription("Read the design plan of the Royal Mausoleum");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ZACHA4F_MQ_03_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(91));

		AddObjective("kill0", "Kill 5 Shtayim(s)", new KillObjective(5, MonsterId.Shtayim));

		AddReward(new ExpReward(245710, 245710));
		AddReward(new ItemReward("Vis", 1800));

		AddDialogHook("ZACHA4F_MQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("ZACHA4F_MQ", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ZACHA4F_MQ_03_select01", "ZACHA4F_MQ_03", "It would be better to stop the attacks destroying the Royal Mausoleum.", "Ignore"))
		{
			case 1:
				character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Stop the Guardians from destroying the Royal Mausoleum!");
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


		return HookResult.Break;
	}
}

