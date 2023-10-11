//--- Melia Script -----------------------------------------------------------
// The Dream Bow Book (3)
//--- Description -----------------------------------------------------------
// Quest to Give the book to the Hunter Master..
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

[QuestScript(72134)]
public class Quest72134Script : QuestScript
{
	protected override void Load()
	{
		SetId(72134);
		SetName("The Dream Bow Book (3)");
		SetDescription("Give the book to the Hunter Master.");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_HUNTER2_3_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(45));
		AddPrerequisite(new CompletedPrerequisite("MASTER_HUNTER1_2"));

		AddReward(new ItemReward("MASTER_HUNTER1_3_ITEM", 1));

		AddDialogHook("JOB_HUNTER2_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_ARCHER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_HUNTER2_3_select1", "MASTER_HUNTER1_3", "I'll go to the Archer Master", "Decline"))
		{
			case 1:
				// Func/SCR_MASTER_HUNTER1_3_START;
				await dialog.Msg("MASTER_HUNTER1_3_DLG1");
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

		ZoneServer.Instance.World.FindNPC("MASTER_ARCHER")?.PlayEffectLocal(character.Connection, "archer_buff_skl_Recuperate_circle", 1.5f, "BOT");
		await dialog.Msg("JOB_HUNTER2_3_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

