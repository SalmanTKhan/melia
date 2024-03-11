//--- Melia Script -----------------------------------------------------------
// Alembique Tales(3)
//--- Description -----------------------------------------------------------
// Quest to Go to Priest Celvica.
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

[QuestScript(60212)]
public class Quest60212Script : QuestScript
{
	protected override void Load()
	{
		SetId(60212);
		SetName("Alembique Tales(3)");
		SetDescription("Go to Priest Celvica");

		AddPrerequisite(new LevelPrerequisite(320));
		AddPrerequisite(new CompletedPrerequisite("LSCAVE551_SQ_2"));

		AddDialogHook("LSCAVE551_CELVERKA_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("LSCAVE551_SQ_3_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LSCAVE551_SQ_3_1", "LSCAVE551_SQ_3", "I have heard it from Heranda.", "Ignore"))
		{
			case 1:
				dialog.HideNPC("LSCAVE551_HELANDA_NPC");
				await dialog.Msg("LSCAVE551_SQ_3_1_1");
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

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("LSCAVE551_SQ_4");
	}
}

