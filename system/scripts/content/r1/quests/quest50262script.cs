//--- Melia Script -----------------------------------------------------------
// Sword Pell Repair (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with the Highlander Submaster.
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

[QuestScript(50262)]
public class Quest50262Script : QuestScript
{
	protected override void Load()
	{
		SetId(50262);
		SetName("Sword Pell Repair (1)");
		SetDescription("Talk with the Highlander Submaster");

		AddPrerequisite(new LevelPrerequisite(1));

		AddObjective("collect0", "Collect 13 Woodin's Sturdy Tree(s)", new CollectItemObjective("SIAULIAI16_HIDDENQ1_ITEM3", 13));
		AddDrop("SIAULIAI16_HIDDENQ1_ITEM3", 10f, "woodin");

		AddDialogHook("JOB_2_HIGHLANDER_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_HIGHLANDER_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI16_HQ1_start1", "SIAULIAI16_HQ1", "I'll take responsibility and repair it.", "I have no idea what you're talking about. Bye."))
		{
			case 1:
				await dialog.Msg("SIAULIAI16_HQ1_agree1");
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
		character.Quests.Start("SIAULIAI16_HQ2");
	}
}

