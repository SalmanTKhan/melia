//--- Melia Script -----------------------------------------------------------
// Investigating the Protection Cast
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

[QuestScript(70401)]
public class Quest70401Script : QuestScript
{
	protected override void Load()
	{
		SetId(70401);
		SetName("Investigating the Protection Cast");
		SetDescription("Talk to Mage Melchioras");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("CASTLE65_1_MQ01"));

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

		switch (await dialog.Select("CASTLE651_MQ_02_start", "CASTLE65_1_MQ02", "Sure, I'll help", "It'll be difficult for me to take part in that"))
		{
			case 1:
				await dialog.Msg("CASTLE651_MQ_02_agree");
				dialog.UnHideNPC("CASTLE651_MQ_02_1");
				dialog.UnHideNPC("CASTLE651_MQ_02_2");
				dialog.UnHideNPC("CASTLE651_MQ_02_3");
				dialog.UnHideNPC("CASTLE651_MQ_02_4");
				dialog.UnHideNPC("CASTLE651_MQ_02_5");
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

