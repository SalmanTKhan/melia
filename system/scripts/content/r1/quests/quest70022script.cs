//--- Melia Script -----------------------------------------------------------
// The Druid's Whereabouts
//--- Description -----------------------------------------------------------
// Quest to Talk to Farm Supervisor Dorn.
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

[QuestScript(70022)]
public class Quest70022Script : QuestScript
{
	protected override void Load()
	{
		SetId(70022);
		SetName("The Druid's Whereabouts");
		SetDescription("Talk to Farm Supervisor Dorn");

		AddPrerequisite(new LevelPrerequisite(152));
		AddPrerequisite(new CompletedPrerequisite("FARM49_2_MQ02"));

		AddDialogHook("FARM492_MQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("FARM492_MQ_04", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM49_2_MQ_03_1", "FARM49_2_MQ03"))
		{
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FARM49_2_MQ_03_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

