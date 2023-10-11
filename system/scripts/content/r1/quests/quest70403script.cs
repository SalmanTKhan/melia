//--- Melia Script -----------------------------------------------------------
// Starting in the Area
//--- Description -----------------------------------------------------------
// Quest to Talk to Mage Melchioras.
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

[QuestScript(70403)]
public class Quest70403Script : QuestScript
{
	protected override void Load()
	{
		SetId(70403);
		SetName("Starting in the Area");
		SetDescription("Talk to Mage Melchioras");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("CASTLE65_1_MQ03"));

		AddReward(new ExpReward(245710, 245710));
		AddReward(new ItemReward("expCard5", 2));
		AddReward(new ItemReward("Vis", 1444));

		AddDialogHook("CASTLE651_MQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE651_MQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE651_MQ_04_start", "CASTLE65_1_MQ04", "What can I help you with?", "I'll help you next time"))
		{
			case 1:
				await dialog.Msg("CASTLE651_MQ_04_agree");
				dialog.HideNPC("CASTLE651_MQ_02_3");
				dialog.UnHideNPC("CASTLE651_MQ_04_3");
				character.AddonMessage(AddonMessage.NOTICE_Dm_Scroll, "Remove the protection spell above Amjene Sanctuary", 5);
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

