//--- Melia Script -----------------------------------------------------------
// Picky Taste [Falconer Advancement]
//--- Description -----------------------------------------------------------
// Quest to Call of the Falconer Master.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;
using Melia.Shared.Tos.Const;

[QuestScript(30000)]
public class Quest30000Script : QuestScript
{
	protected override void Load()
	{
		SetId(30000);
		SetName("Picky Taste [Falconer Advancement]");
		SetDescription("Call of the Falconer Master");

		AddPrerequisite(new LevelPrerequisite(185));

		AddDialogHook("MASTER_FALCONER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_FALCONER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_FALCONER5_1_select", "JOB_FALCONER5_1", "I'll get it", "I can't do such tiresome duties"))
			{
				case 1:
					await dialog.Msg("JOB_FALCONER5_1_agree");
					character.Quests.Start(this.QuestId);
					break;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			if (character.Inventory.HasItem("JOB_FALCONER5_1_ITEM", 20))
			{
				character.Inventory.RemoveItem("JOB_FALCONER5_1_ITEM", 20);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("JOB_FALCONER5_1_succ");
				dialog.AddonMessage("NOTICE_Dm_Clear", "If you don't have a Hawk, you can adopt one for free at the Companion Trader!");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

