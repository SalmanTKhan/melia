//--- Melia Script -----------------------------------------------------------
// Dog Eat Dog
//--- Description -----------------------------------------------------------
// Quest to Talk with Alchemist Sophia.
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

[QuestScript(70729)]
public class Quest70729Script : QuestScript
{
	protected override void Load()
	{
		SetId(70729);
		SetName("Dog Eat Dog");
		SetDescription("Talk with Alchemist Sophia");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "BRACKEN42_2_SQ10_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(282));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN42_2_SQ09"));

		AddObjective("collect0", "Collect 2 Centaurus Crystal(s)", new CollectItemObjective("BRACKEN42_2_SQ10_ITEM", 2));
		AddDrop("BRACKEN42_2_SQ10_ITEM", 10f, "boss_Centaurus_Q2");

		AddReward(new ExpReward(7261044, 7261044));
		AddReward(new ItemReward("expCard13", 5));
		AddReward(new ItemReward("Vis", 11844));

		AddDialogHook("BRACKEN422_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN422_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN422_SQ_10_start", "BRACKEN42_2_SQ10", "A bit challenging, I amit. But I will try.", "Centauri? Seriously? Centauri? No way. I'm out."))
		{
			case 1:
				await dialog.Msg("BRACKEN422_SQ_10_agree");
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

		if (character.Inventory.HasItem("BRACKEN42_2_SQ10_ITEM", 2))
		{
			character.Inventory.RemoveItem("BRACKEN42_2_SQ10_ITEM", 2);
			await dialog.Msg("BRACKEN422_SQ_10_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

