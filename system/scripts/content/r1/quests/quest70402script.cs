//--- Melia Script -----------------------------------------------------------
// All For a Bigger Blow
//--- Description -----------------------------------------------------------
// Quest to Talk to Revelator Mihail.
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

[QuestScript(70402)]
public class Quest70402Script : QuestScript
{
	protected override void Load()
	{
		SetId(70402);
		SetName("All For a Bigger Blow");
		SetDescription("Talk to Revelator Mihail");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("CASTLE65_1_MQ02"));

		AddReward(new ExpReward(245710, 245710));
		AddReward(new ItemReward("expCard5", 2));
		AddReward(new ItemReward("Vis", 1444));

		AddDialogHook("CASTLE651_MQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE651_MQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE651_MQ_03_start", "CASTLE65_1_MQ03", "Okay", "Tell me about the Revelators of Klaipeda", "I'll wait for Melchioras to get ready"))
		{
			case 1:
				await dialog.Msg("CASTLE651_MQ_03_agree");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("CASTLE651_MQ_03_add");
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

