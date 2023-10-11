//--- Melia Script -----------------------------------------------------------
// Kenneth's Protector
//--- Description -----------------------------------------------------------
// Quest to Talk to Watcher Kenneth.
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

[QuestScript(8542)]
public class Quest8542Script : QuestScript
{
	protected override void Load()
	{
		SetId(8542);
		SetName("Kenneth's Protector");
		SetDescription("Talk to Watcher Kenneth");

		AddPrerequisite(new LevelPrerequisite(32));

		AddObjective("kill0", "Kill 9 Green Puragi(s) or Banshee(s) or Brown Zigri(s)", new KillObjective(9, 400303, 400101, 400322));

		AddReward(new ExpReward(50652, 50652));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("Vis", 448));

		AddDialogHook("GELE573_KENNETH", "BeforeStart", BeforeStart);
		AddDialogHook("GELE573_KAROLINA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("GELE573_MQ_05_01", "GELE573_MQ_05", "I'll defeat the demons while resting", "Cheer up and hold on"))
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

		await dialog.Msg("GELE573_MQ_05_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

