//--- Melia Script -----------------------------------------------------------
// Contacts
//--- Description -----------------------------------------------------------
// Quest to Talk with Liaison Officer Rochez.
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

[QuestScript(70220)]
public class Quest70220Script : QuestScript
{
	protected override void Load()
	{
		SetId(70220);
		SetName("Contacts");
		SetDescription("Talk with Liaison Officer Rochez");

		AddPrerequisite(new LevelPrerequisite(215));

		AddObjective("kill0", "Kill 12 Blue Siaulav(s) or Blue Siaulav Archer(s) or Blue Lapasape(s)", new KillObjective(12, 57897, 57900, 57941));

		AddReward(new ExpReward(1082046, 1082046));
		AddReward(new ItemReward("expCard11", 4));
		AddReward(new ItemReward("Vis", 7525));

		AddDialogHook("TABLELAND282_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("TABLELAND282_SQ_05", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND28_2_SQ_01_1", "TABLELAND28_2_SQ01", "I will deliver the message for you", "I don't want to get involved in a difficult situation"))
		{
			case 1:
				await dialog.Msg("TABLELAND28_2_SQ_01_2");
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

		await dialog.Msg("TABLELAND28_2_SQ_01_4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

