//--- Melia Script -----------------------------------------------------------
// Empty Slate
//--- Description -----------------------------------------------------------
// Quest to Read the epitaph.
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

[QuestScript(8422)]
public class Quest8422Script : QuestScript
{
	protected override void Load()
	{
		SetId(8422);
		SetName("Empty Slate");
		SetDescription("Read the epitaph");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ZACHA5F_EQ_04_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(94));

		AddObjective("kill0", "Kill 6 Rusrat(s)", new KillObjective(6, MonsterId.Schlesien_Claw));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 1880));

		AddDialogHook("ZACHA5F_EQ_04", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ZACHA5F_EQ_04_select01", "ZACHA5F_EQ_04"))
		{
		}

		return HookResult.Break;
	}
}

