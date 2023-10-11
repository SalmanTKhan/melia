//--- Melia Script -----------------------------------------------------------
// The Journey Begins (3) - Removed
//--- Description -----------------------------------------------------------
// Quest to Talk with Settler Brophen.
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

[QuestScript(60072)]
public class Quest60072Script : QuestScript
{
	protected override void Load()
	{
		SetId(60072);
		SetName("The Journey Begins (3) - Removed");
		SetDescription("Talk with Settler Brophen");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("SIAU16_MQ_02"));

		AddDialogHook("SIAULIAI16_BROPHEN", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI16_BROPHEN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


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

