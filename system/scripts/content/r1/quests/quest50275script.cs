//--- Melia Script -----------------------------------------------------------
// Ferrets and Their Grabby Hands
//--- Description -----------------------------------------------------------
// Quest to Talk to the Village Headman.
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

[QuestScript(50275)]
public class Quest50275Script : QuestScript
{
	protected override void Load()
	{
		SetId(50275);
		SetName("Ferrets and Their Grabby Hands");
		SetDescription("Talk to the Village Headman");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("collect0", "Collect 10 Ritual Device(s)", new CollectItemObjective("ORCHARD323_HIDDENQ1_ITEM2", 10));
		AddDrop("ORCHARD323_HIDDENQ1_ITEM2", 10f, 57852, 57854);

		AddReward(new ItemReward("misc_scrollskulp", 1));

		AddDialogHook("ORCHARD323_MAYOR", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD323_MAYOR", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORCHARD32_3_HQ1_start1", "ORCHARD32_3_HQ1", "I'll get back the offering tools.", "Do it yourself."))
		{
			case 1:
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

