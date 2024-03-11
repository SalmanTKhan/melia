//--- Melia Script -----------------------------------------------------------
// Reserved Records of the Cleric [Pardoner Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Pardoner Master.
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

[QuestScript(30046)]
public class Quest30046Script : QuestScript
{
	protected override void Load()
	{
		SetId(30046);
		SetName("Reserved Records of the Cleric [Pardoner Advancement]");
		SetDescription("Talk to the Pardoner Master");

		AddPrerequisite(new LevelPrerequisite(235));

		AddDialogHook("JOB_PARDONER4_1", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_PARDONER4_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_PARDONER_6_1_select", "JOB_PARDONER_6_1", "I will go find the book", "I will return next time"))
		{
			case 1:
				await dialog.Msg("JOB_PARDONER_6_1_agree");
				dialog.UnHideNPC("JOB_PARDONER_6_1_NOTE01");
				dialog.UnHideNPC("JOB_PARDONER_6_1_NOTE02");
				dialog.UnHideNPC("JOB_PARDONER_6_1_NOTE03");
				dialog.UnHideNPC("JOB_PARDONER_6_1_NOTE04");
				dialog.UnHideNPC("JOB_PARDONER_6_1_NOTE05");
				dialog.UnHideNPC("JOB_PARDONER_6_1_NOTE06");
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

		if (character.Inventory.HasItem("JOB_PARDONER_6_1_ITEM", 1))
		{
			character.Inventory.RemoveItem("JOB_PARDONER_6_1_ITEM", 1);
			await dialog.Msg("JOB_PARDONER_6_1_succ");
			dialog.HideNPC("JOB_PARDONER_6_1_NOTE01");
			dialog.HideNPC("JOB_PARDONER_6_1_NOTE02");
			dialog.HideNPC("JOB_PARDONER_6_1_NOTE03");
			dialog.HideNPC("JOB_PARDONER_6_1_NOTE04");
			dialog.HideNPC("JOB_PARDONER_6_1_NOTE05");
			dialog.HideNPC("JOB_PARDONER_6_1_NOTE06");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

