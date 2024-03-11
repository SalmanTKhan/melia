//--- Melia Script -----------------------------------------------------------
// The Best Material [Dievdirbys Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to Sculptor Tesla.
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

[QuestScript(1100)]
public class Quest1100Script : QuestScript
{
	protected override void Load()
	{
		SetId(1100);
		SetName("The Best Material [Dievdirbys Advancement]");
		SetDescription("Talk to Sculptor Tesla");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_DIEVDIRBYS2_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(45));

		AddObjective("collect0", "Collect 1 Blue Crystal", new CollectItemObjective("JOB_DIEVDIRBYS2_ITEM1", 1));
		AddDrop("JOB_DIEVDIRBYS2_ITEM1", 10f, "boss_yekub_J1");

		AddObjective("kill0", "Kill 1 Yekub", new KillObjective(1, MonsterId.Boss_Yekub_J1));

		AddDialogHook("JOB_DIEVDIRBYS2_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_DIEVDIRBYS2_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_DIEVDIRBYS2_select1", "JOB_DIEVDIRBYS2", "Where are the crystals found?", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_DIEVDIRBYS2_agree1");
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

		if (character.Inventory.HasItem("JOB_DIEVDIRBYS2_ITEM1", 1))
		{
			character.Inventory.RemoveItem("JOB_DIEVDIRBYS2_ITEM1", 1);
			await dialog.Msg("JOB_DIEVDIRBYS2_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

