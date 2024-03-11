//--- Melia Script -----------------------------------------------------------
// Wrong Faith (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Villager Duncan.
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

[QuestScript(80081)]
public class Quest80081Script : QuestScript
{
	protected override void Load()
	{
		SetId(80081);
		SetName("Wrong Faith (2)");
		SetDescription("Talk with Villager Duncan");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ABBEY_35_3_SQ_4_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(229));
		AddPrerequisite(new CompletedPrerequisite("ABBEY_35_3_SQ_3"));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 63));
		AddReward(new ItemReward("Vis", 8244));

		AddDialogHook("ABBEY_35_3_VILLAGE_B_2", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY_35_3_VILLAGE_B_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY_35_3_SQ_4_start", "ABBEY_35_3_SQ_4", "Is it really okay?", "I'm not interested"))
		{
			case 1:
				await dialog.Msg("ABBEY_35_3_SQ_4_agree");
				dialog.HideNPC("ABBEY_35_3_VILLAGE_B_2");
				// Func/ABBEY_35_3_SQ_4_NPC;
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

		await dialog.Msg("ABBEY_35_3_SQ_4_succ");
		// Func/ABBEY_35_3_SQ_4_COMP;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

