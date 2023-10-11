//--- Melia Script -----------------------------------------------------------
// My Ring!
//--- Description -----------------------------------------------------------
// Quest to Talk to Believer Adele.
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

[QuestScript(20250)]
public class Quest20250Script : QuestScript
{
	protected override void Load()
	{
		SetId(20250);
		SetName("My Ring!");
		SetDescription("Talk to Believer Adele");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "THORN19_MQ06_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(58));

		AddObjective("collect0", "Collect 1 Adele's Ring", new CollectItemObjective("THORN19_MQ6_POISON", 1));
		AddDrop("THORN19_MQ6_POISON", 10f, "boss_Chafer_Q1");

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("misc_NECK03_104_2", 1));
		AddReward(new ItemReward("Vis", 1044));

		AddDialogHook("THORN19_BELIEVER02", "BeforeStart", BeforeStart);
		AddDialogHook("THORN19_BELIEVER02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN19_MQ06_select01", "THORN19_MQ06", "I will find your ring and bring it to you", "It's probably digested by now"))
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

		if (character.Inventory.HasItem("THORN19_MQ6_POISON", 1))
		{
			character.Inventory.RemoveItem("THORN19_MQ6_POISON", 1);
			await dialog.Msg("THORN19_MQ06_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

