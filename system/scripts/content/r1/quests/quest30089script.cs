//--- Melia Script -----------------------------------------------------------
// Dungeon Crawl [Hunter Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Hunter Submaster.
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

[QuestScript(30089)]
public class Quest30089Script : QuestScript
{
	protected override void Load()
	{
		SetId(30089);
		SetName("Dungeon Crawl [Hunter Advancement]");
		SetDescription("Talk to the Hunter Submaster");

		AddPrerequisite(new LevelPrerequisite(45));

		AddDialogHook("JOB_2_HUNTER_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_HUNTER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_HUNTER_3_1_select", "JOB_2_HUNTER_3_1", "Ask what you should do", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_2_HUNTER_3_1_agree");
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

		await dialog.Msg("JOB_2_HUNTER_3_1_succ");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "If you don't have a Velheider, you can adopt one for free at the Companion Trader!");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

