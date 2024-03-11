//--- Melia Script -----------------------------------------------------------
// Dream Book of the Bow 3 [Archer Advancement] (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Archer Master.
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

[QuestScript(1091)]
public class Quest1091Script : QuestScript
{
	protected override void Load()
	{
		SetId(1091);
		SetName("Dream Book of the Bow 3 [Archer Advancement] (1)");
		SetDescription("Talk to the Archer Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_HUNTER2_1_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(45));

		AddObjective("collect0", "Collect 1 Lydia Schaffen's Notch", new CollectItemObjective("Book5", 1));
		AddDrop("Book5", 10f, "boss_Goblin_Warrior_J2");

		AddDialogHook("MASTER_ARCHER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_ARCHER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_ARCHER2_1_select1", "JOB_ARCHER2_1", "I'll go find the book", "I will get it again later"))
		{
			case 1:
				await dialog.Msg("JOB_ARCHER2_1_prog1");
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

		if (character.Inventory.HasItem("Book5", 1))
		{
			character.Inventory.RemoveItem("Book5", 1);
			ZoneServer.Instance.World.FindNPC("MASTER_ARCHER")?.PlayEffectLocal(character.Connection, "archer_buff_skl_Recuperate_circle", 1.5f, "BOT");
			await dialog.Msg("JOB_ARCHER2_1_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("JOB_ARCHER2_2");
	}
}

