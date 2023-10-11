//--- Melia Script -----------------------------------------------------------
// Large-Scale Search Operation (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Chaser Talbasi.
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

[QuestScript(60100)]
public class Quest60100Script : QuestScript
{
	protected override void Load()
	{
		SetId(60100);
		SetName("Large-Scale Search Operation (2)");
		SetDescription("Talk with Chaser Talbasi");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("SIAU11RE_MQ_01"));

		AddReward(new ExpReward(13430, 13430));
		AddReward(new ItemReward("expCard2", 1));
		AddReward(new ItemReward("Vis", 169));

		AddDialogHook("SIAULIAI11RE_TALBASI", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAU11RE_MQ_02_01", "SIAU11RE_MQ_02", "Yes, I'll drop by", "Let me get ready first"))
		{
			case 1:
				await dialog.Msg("SIAU11RE_MQ_02_01_AG");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

