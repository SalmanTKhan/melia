//--- Melia Script -----------------------------------------------------------
// The Second Epitaph (3)
//--- Description -----------------------------------------------------------
// Quest to Ask the blacksmith in Klaipeda about adhesives.
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

[QuestScript(40610)]
public class Quest40610Script : QuestScript
{
	protected override void Load()
	{
		SetId(40610);
		SetName("The Second Epitaph (3)");
		SetDescription("Ask the blacksmith in Klaipeda about adhesives");

		AddPrerequisite(new LevelPrerequisite(172));
		AddPrerequisite(new CompletedPrerequisite("REMAINS37_2_SQ_031"));

		AddDialogHook("BLACKSMITH", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS37_2_MT02_BROKEN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAINS37_2_SQ_032_ST", "REMAINS37_2_SQ_032", "Tell him that you understand", "Tell him that you will look for other methods"))
		{
			case 1:
				await dialog.Msg("REMAINS37_2_SQ_032_ACC");
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

		character.AddonMessage(AddonMessage.NOTICE_Dm_Exclaimation, "Make the glue the blacksmith advised to you", 5);
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("REMAINS37_2_SQ_040");
	}
}

