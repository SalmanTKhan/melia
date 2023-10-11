//--- Melia Script -----------------------------------------------------------
// Preparing for Battle (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Soldier Callans.
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

[QuestScript(50153)]
public class Quest50153Script : QuestScript
{
	protected override void Load()
	{
		SetId(50153);
		SetName("Preparing for Battle (5)");
		SetDescription("Talk to Soldier Callans");

		AddPrerequisite(new LevelPrerequisite(238));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_70_SQ7"));

		AddReward(new ExpReward(2955183, 2955183));
		AddReward(new ItemReward("expCard12", 1));
		AddReward(new ItemReward("Vis", 68544));

		AddDialogHook("TABLE70_SOLDIER3_1", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE70_SOLDIER3_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_70_SQ8_startnpc01", "TABLELAND_70_SQ8", "Let's set it up together", "I'll set it up myself"))
		{
			case 1:
				await dialog.Msg("TABLELAND_70_SQ8_startnpc02");
				dialog.HideNPC("TABLE70_SOLDIER3_1");
				await dialog.Msg("FadeOutIN/1000");
				// Func/TABLE70_SUBQ8_AGREE_FUNC;
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

		await dialog.Msg("TABLELAND_70_SQ8_succ01");
		await dialog.Msg("FadeOutIN/1000");
		dialog.UnHideNPC("TABLE70_SOLDIER4_1");
		dialog.UnHideNPC("TABLE70_SOLDIER5_1");
		dialog.UnHideNPC("TABLE70_SOLDIER6_1");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "The soldiers sent to relay the fake report to the demons are back.");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

