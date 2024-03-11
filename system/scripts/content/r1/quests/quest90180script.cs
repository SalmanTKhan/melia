//--- Melia Script -----------------------------------------------------------
// Missing Herbalist (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Herbalist Ash.
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

[QuestScript(90180)]
public class Quest90180Script : QuestScript
{
	protected override void Load()
	{
		SetId(90180);
		SetName("Missing Herbalist (3)");
		SetDescription("Talk to Herbalist Ash");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("LOWLV_GREEN_SQ_30"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("misc_ore17", 1));
		AddReward(new ItemReward("Vis", 12180));

		AddDialogHook("BRACKEN632_PEAPLE01", "BeforeStart", BeforeStart);
		AddDialogHook("LOWLV_GREEN_SQ_40_BOX", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LOWLV_GREEN_SQ_40_ST", "LOWLV_GREEN_SQ_40"))
		{
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

