//--- Melia Script -----------------------------------------------------------
// Dream Book of the Bow 4 [Ranger Advancement] (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Ranger Master.
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

[QuestScript(1095)]
public class Quest1095Script : QuestScript
{
	protected override void Load()
	{
		SetId(1095);
		SetName("Dream Book of the Bow 4 [Ranger Advancement] (1)");
		SetDescription("Talk to the Ranger Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_HUNTER2_1_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(45));

		AddObjective("collect0", "Collect 1 Lydia Schaffen and Rumpelstiltskin ", new CollectItemObjective("Book6", 1));
		AddDrop("Book6", 10f, "boss_Goblin_Warrior_J2");

		AddDialogHook("MASTER_RANGER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_RANGER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_RANGER2_1_select1", "JOB_RANGER2_1", "I'll go find the book", "I don't have time for that"))
		{
			case 1:
				await dialog.Msg("JOB_RANGER2_1_prog1");
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

		if (character.Inventory.HasItem("Book6", 1))
		{
			character.Inventory.RemoveItem("Book6", 1);
			ZoneServer.Instance.World.FindNPC("MASTER_RANGER")?.PlayEffectLocal(character.Connection, "archer_buff_skl_Recuperate_circle", 1.5f, "BOT");
			await dialog.Msg("JOB_RANGER2_1_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("JOB_RANGER2_2");
	}
}

