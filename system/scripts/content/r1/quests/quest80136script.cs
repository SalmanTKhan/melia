//--- Melia Script -----------------------------------------------------------
// Dwindling Energy
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Alena.
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

[QuestScript(80136)]
public class Quest80136Script : QuestScript
{
	protected override void Load()
	{
		SetId(80136);
		SetName("Dwindling Energy");
		SetDescription("Talk to Kupole Alena");

		AddPrerequisite(new LevelPrerequisite(291));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_5_MQ_10"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 12222));

		AddDialogHook("LIMESTONE_52_2_ALLENA", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONE_52_2_ALLENA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_2_SQ_2_start", "LIMESTONE_52_2_SQ_2", "I'll be right back.", "I'm busy now"))
		{
			case 1:
				await dialog.Msg("BalloonText/LIMESTONE_52_2_SQ_2_agree/6");
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

		if (character.Inventory.HasItem("LIMESTONE_52_2_MQ_8_HEALSTONE_F", 1))
		{
			character.Inventory.RemoveItem("LIMESTONE_52_2_MQ_8_HEALSTONE_F", 1);
			await dialog.Msg("LIMESTONE_52_2_SQ_2_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

