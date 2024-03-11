//--- Melia Script -----------------------------------------------------------
// A Book Not of This World (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Linker Master.
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

[QuestScript(72170)]
public class Quest72170Script : QuestScript
{
	protected override void Load()
	{
		SetId(72170);
		SetName("A Book Not of This World (2)");
		SetDescription("Talk to the Linker Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_LINKER2_2_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(45));
		AddPrerequisite(new CompletedPrerequisite("SUBMASTER_LINKER1_1"));

		AddReward(new ItemReward("Point_Stone_100_Q", 1));

		AddDialogHook("JOB_LINKER2_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_LINKER2_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SUBMASTER_LINKER1_2_DLG1", "SUBMASTER_LINKER1_2", "Alright", "That's too much"))
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

		if (character.Inventory.HasItem("SUBMASTER_LINKER1_2_ITEM02", 1))
		{
			character.Inventory.RemoveItem("SUBMASTER_LINKER1_2_ITEM02", 1);
			//SCR_SUBMASTER_LINKER1_2_GIVE_BOOK
			ZoneServer.Instance.World.FindNPC("JOB_LINKER2_1_NPC")?.PlayEffectLocal(character.Connection, "archer_buff_skl_Recuperate_circle", 1.5f, "BOT");
			await dialog.Msg("SUBMASTER_LINKER1_2_DLG3");
			await dialog.Msg("FadeOutIN/1000");
			await dialog.Msg("SUBMASTER_LINKER1_2_DLG4");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

