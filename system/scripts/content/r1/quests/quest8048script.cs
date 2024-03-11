//--- Melia Script -----------------------------------------------------------
// Find the Supply Commander's Junior
//--- Description -----------------------------------------------------------
// Quest to Talk to Vio.
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

[QuestScript(8048)]
public class Quest8048Script : QuestScript
{
	protected override void Load()
	{
		SetId(8048);
		SetName("Find the Supply Commander's Junior");
		SetDescription("Talk to Vio");

		AddPrerequisite(new LevelPrerequisite(64));
		AddPrerequisite(new CompletedPrerequisite("ROKAS26_SUB_Q11"));

		AddDialogHook("ROKAS26_BIO", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS26_SUB_Q12_select_01", "ROKAS26_SUB_Q12"))
		{
		}

		return HookResult.Break;
	}
}

