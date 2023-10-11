//--- Melia Script -----------------------------------------------------------
// Strange Sculture (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Owynia Dilben.
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

[QuestScript(50376)]
public class Quest50376Script : QuestScript
{
	protected override void Load()
	{
		SetId(50376);
		SetName("Strange Sculture (2)");
		SetDescription("Talk to Owynia Dilben");

		AddPrerequisite(new LevelPrerequisite(381));
		AddPrerequisite(new CompletedPrerequisite("F_NICOPOLIS_81_1_SQ_01"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 30000));

		AddDialogHook("NICO811_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("NICO811_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("NICO811_SUBQ2_START", "F_NICOPOLIS_81_1_SQ_02", "I'll suppress the evil energy.", "I'm afraid I must refuse."))
		{
			case 1:
				// Func/SCR_NICOPOLIS_811_SUBQ01;
				await dialog.Msg("NICO811_SUBQ2_AGREE1");
				dialog.HideNPC("NICO811_NPC1");
				await dialog.Msg("FadeOutIN/1000");
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


		return HookResult.Break;
	}
}

