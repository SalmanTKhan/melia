//--- Melia Script -----------------------------------------------------------
// Lydia Schaffen and the Fletcher's Arrow [Fletcher Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Fletcher Master.
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

[QuestScript(30042)]
public class Quest30042Script : QuestScript
{
	protected override void Load()
	{
		SetId(30042);
		SetName("Lydia Schaffen and the Fletcher's Arrow [Fletcher Advancement]");
		SetDescription("Talk to the Fletcher Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_FLETCHER_6_1_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(235));

		AddObjective("collect0", "Collect 1 Arrow of the First Fletcher Master", new CollectItemObjective("JOB_FLETCHER_6_1_ITEM", 1));
		AddDrop("JOB_FLETCHER_6_1_ITEM", 10f, "boss_Templeshooter_J2");

		AddDialogHook("MASTER_FLETCHER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_FLETCHER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_FLETCHER_6_1_select", "JOB_FLETCHER_6_1", "I will take the challenge", "I am not confident enough"))
		{
			case 1:
				await dialog.Msg("JOB_FLETCHER_6_1_agree");
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

		if (character.Inventory.HasItem("JOB_FLETCHER_6_1_ITEM", 1))
		{
			character.Inventory.RemoveItem("JOB_FLETCHER_6_1_ITEM", 1);
			await dialog.Msg("JOB_FLETCHER_6_1_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

