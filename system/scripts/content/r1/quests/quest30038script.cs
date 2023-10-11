//--- Melia Script -----------------------------------------------------------
// Things Left Behind Death [Necromancer Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Necromancer Master.
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

[QuestScript(30038)]
public class Quest30038Script : QuestScript
{
	protected override void Load()
	{
		SetId(30038);
		SetName("Things Left Behind Death [Necromancer Advancement]");
		SetDescription("Talk to the Necromancer Master");

		AddPrerequisite(new LevelPrerequisite(235));

		AddDialogHook("JOB_NECRO4_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_NECRO4_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_NECROMANCER_6_1_select", "JOB_NECROMANCER_6_1", "I'll get it", "I don't have guts for it"))
		{
			case 1:
				await dialog.Msg("JOB_NECROMANCER_6_1_agree");
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

		if (character.Inventory.HasItem("JOB_NECROMANCER_6_1_ITEM", 1))
		{
			character.Inventory.RemoveItem("JOB_NECROMANCER_6_1_ITEM", 1);
			await dialog.Msg("JOB_NECROMANCER_6_1_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

