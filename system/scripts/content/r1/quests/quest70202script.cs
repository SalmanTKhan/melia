//--- Melia Script -----------------------------------------------------------
// Mesafasla, the Strategic Spot (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Mesafasla Assistant Commander Gorman.
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

[QuestScript(70202)]
public class Quest70202Script : QuestScript
{
	protected override void Load()
	{
		SetId(70202);
		SetName("Mesafasla, the Strategic Spot (1)");
		SetDescription("Talk with Mesafasla Assistant Commander Gorman");

		AddPrerequisite(new LevelPrerequisite(212));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND28_1_SQ02"));

		AddDialogHook("TABLELAND281_SQ_01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND28_1_SQ_03_1", "TABLELAND28_1_SQ03"))
		{
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("TABLELAND28_1_SQ04");
	}
}

