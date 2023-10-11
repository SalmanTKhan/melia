//--- Melia Script -----------------------------------------------------------
// Destroyed Barrier
//--- Description -----------------------------------------------------------
// Quest to Talk to Watcher Allen.
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

[QuestScript(8538)]
public class Quest8538Script : QuestScript
{
	protected override void Load()
	{
		SetId(8538);
		SetName("Destroyed Barrier");
		SetDescription("Talk to Watcher Allen");

		AddPrerequisite(new LevelPrerequisite(32));

		AddReward(new ExpReward(50652, 50652));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("Vis", 448));

		AddDialogHook("GELE573_ALLEN", "BeforeStart", BeforeStart);
		AddDialogHook("GELE573_KAROLINA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("GELE573_MQ_01_01", "GELE573_MQ_01", "I'll help if it's simple", "About the barriers in Nefritas Cliff", "I'm busy on my way"))
		{
			case 1:
				dialog.UnHideNPC("GELE573_MQ_01");
				await dialog.Msg("GELE573_MQ_01_01_R");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("GELE573_MQ_01_01_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("GELE573_MQ_01_03");
		dialog.HideNPC("GELE573_MQ_01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

