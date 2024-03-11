//--- Melia Script -----------------------------------------------------------
// Astral Tracing (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Hunter Talus.
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

[QuestScript(20208)]
public class Quest20208Script : QuestScript
{
	protected override void Load()
	{
		SetId(20208);
		SetName("Astral Tracing (1)");
		SetDescription("Talk to Hunter Talus");

		AddPrerequisite(new LevelPrerequisite(99));

		AddReward(new ExpReward(122855, 122855));
		AddReward(new ItemReward("expCard6", 1));
		AddReward(new ItemReward("Vis", 1980));

		AddDialogHook("REMAIN38_HUNTER", "BeforeStart", BeforeStart);
		AddDialogHook("REMAIN38_MQ_MONUMENT1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAIN38_MQ01_select01", "REMAIN38_MQ01", "I am interested", "About Lydia Schaffen", "Decline"))
		{
			case 1:
				await dialog.Msg("REMAIN38_MQ01_AG");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("REMAIN38_MQ01_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You've examined the first tombstone of Lydia Schaffen{nl}Examine the remaining tombstones!");
		await dialog.Msg("REMAIN38_MQ01_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("REMAIN38_MQ02");
	}
}

