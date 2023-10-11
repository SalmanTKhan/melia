//--- Melia Script -----------------------------------------------------------
// Clear the Corruption (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Hunter Modis.
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

[QuestScript(90013)]
public class Quest90013Script : QuestScript
{
	protected override void Load()
	{
		SetId(90013);
		SetName("Clear the Corruption (4)");
		SetDescription("Talk to Hunter Modis");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_84_MQ_03"));

		AddObjective("collect0", "Collect 8 Bait Meat(s)", new CollectItemObjective("F_3CMLAKE_84_MQ_ITEM3", 8));
		AddDrop("F_3CMLAKE_84_MQ_ITEM3", 10f, 57686, 58101);

		AddDialogHook("3CMLAKE_84_HUNTER", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_84_HUNTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("3CMLAKE_84_MQ_04_DLG_01", "F_3CMLAKE_84_MQ_04", "I'll get it", "I'll wait until you're done with the trap"))
		{
			case 1:
				await dialog.Msg("3CMLAKE_84_MQ_04_DLG_02");
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
		character.Quests.Start("F_3CMLAKE_84_MQ_05");
	}
}

