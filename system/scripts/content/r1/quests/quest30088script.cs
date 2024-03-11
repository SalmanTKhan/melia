//--- Melia Script -----------------------------------------------------------
// Sapper Research [Sapper Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sapper Submaster.
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

[QuestScript(30088)]
public class Quest30088Script : QuestScript
{
	protected override void Load()
	{
		SetId(30088);
		SetName("Sapper Research [Sapper Advancement]");
		SetDescription("Talk to the Sapper Submaster");

		AddPrerequisite(new LevelPrerequisite(45));

		AddDialogHook("JOB_2_SAPPER_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_SAPPER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_SAPPER_3_1_select", "JOB_2_SAPPER_3_1", "Tell him you would challenge for it", "That's a little out of my league"))
		{
			case 1:
				await dialog.Msg("JOB_2_SAPPER_3_1_agree");
				dialog.UnHideNPC("JOB_2_RANGER_3_1_OBJ_STONE");
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

		if (character.Inventory.HasItem("JOB_2_SAPPER_3_1_ITEM", 10))
		{
			character.Inventory.RemoveItem("JOB_2_SAPPER_3_1_ITEM", 10);
			await dialog.Msg("JOB_2_SAPPER_3_1_succ");
			dialog.HideNPC("JOB_2_RANGER_3_1_OBJ_STONE");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

