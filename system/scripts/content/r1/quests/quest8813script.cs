//--- Melia Script -----------------------------------------------------------
// Cleaning Up
//--- Description -----------------------------------------------------------
// Quest to Talk to Guard Gofden.
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

[QuestScript(8813)]
public class Quest8813Script : QuestScript
{
	protected override void Load()
	{
		SetId(8813);
		SetName("Cleaning Up");
		SetDescription("Talk to Guard Gofden");

		AddPrerequisite(new LevelPrerequisite(187));

		AddObjective("kill0", "Kill 9 Haze(s) or Bavon(s) or Saltisdaughter Magician(s)", new KillObjective(9, 47469, 47471, 57628));

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("Vis", 5797));

		AddDialogHook("FLASH60_GOFDEN", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH60_GOFDEN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH60_SQ_01_01", "FLASH60_SQ_01", "Tell him that you can defeat monsters on behalf of him", "About the Knights of Kaliss", "Cheer him up"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FLASH60_SQ_01_01_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FLASH60_SQ_01_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

