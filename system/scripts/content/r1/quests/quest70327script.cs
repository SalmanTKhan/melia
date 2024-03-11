//--- Melia Script -----------------------------------------------------------
// Charm Requirements [Bokor Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with Bokor Submaster.
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

[QuestScript(70327)]
public class Quest70327Script : QuestScript
{
	protected override void Load()
	{
		SetId(70327);
		SetName("Charm Requirements [Bokor Advancement]");
		SetDescription("Talk with Bokor Submaster");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("collect0", "Collect 35 Monster Blood(s)", new CollectItemObjective("JOB_BOKOR3_ITEM1", 35));
		AddDrop("JOB_BOKOR3_ITEM1", 9f, 58074, 58109, 58072);

		AddDialogHook("JOB_2_BOKOR_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_BOKOR_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_BOKOR4_1_1", "JOB_2_BOKOR4", "Go and gather monster's blood", "Decline"))
		{
			case 1:
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
}

