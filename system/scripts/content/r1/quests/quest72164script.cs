//--- Melia Script -----------------------------------------------------------
// Rebuilding the Study of Magic
//--- Description -----------------------------------------------------------
// Quest to Talk with the Sage Master.
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

[QuestScript(72164)]
public class Quest72164Script : QuestScript
{
	protected override void Load()
	{
		SetId(72164);
		SetName("Rebuilding the Study of Magic");
		SetDescription("Talk with the Sage Master");

		AddPrerequisite(new LevelPrerequisite(285));

		AddReward(new ItemReward("Point_Stone_100_Q", 2));

		AddDialogHook("SAGE_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("SAGE_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MASTER_SAGE1_DLG1", "MASTER_SAGE1", "I will try", "This looks like a job for somebody else."))
		{
			case 1:
				await dialog.Msg("JOB_SAGE_8_1_AGREE1");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		//SCR_MASTER_SAGE1_GIVE_BOOK
		ZoneServer.Instance.World.FindNPC("JOB_LINKER2_1_NPC")?.PlayEffectLocal(character.Connection, "archer_buff_skl_Recuperate_circle", 1.5f, "BOT");
		await dialog.Msg("MASTER_SAGE1_DLG2");
		await dialog.Msg("FadeOutIN/1000");
		await dialog.Msg("MASTER_SAGE1_DLG3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

