//--- Melia Script -----------------------------------------------------------
// The Journey Begins (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Settler Browein.
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

[QuestScript(60070)]
public class Quest60070Script : QuestScript
{
	protected override void Load()
	{
		SetId(60070);
		SetName("The Journey Begins (1)");
		SetDescription("Talk with Settler Browein");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("SIAULIAI16_BOWEIN", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI16_BOWEIN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAU16_MQ_01_01", "SIAU16_MQ_01"))
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

