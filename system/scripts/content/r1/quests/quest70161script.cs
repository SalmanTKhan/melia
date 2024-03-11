//--- Melia Script -----------------------------------------------------------
// Mission to Retake the Monastery (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Senior Monk Goss.
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

[QuestScript(70161)]
public class Quest70161Script : QuestScript
{
	protected override void Load()
	{
		SetId(70161);
		SetName("Mission to Retake the Monastery (2)");
		SetDescription("Talk to Senior Monk Goss");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ABBEY39_4_MQ02_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(183));
		AddPrerequisite(new CompletedPrerequisite("ABBEY39_4_MQ01"));

		AddReward(new ExpReward(1256004, 1256004));
		AddReward(new ItemReward("expCard9", 4));
		AddReward(new ItemReward("Vis", 5673));

		AddDialogHook("ABBEY394_MQ_02", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY394_MQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY39_4_MQ_02_1", "ABBEY39_4_MQ02"))
		{
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

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ABBEY39_4_MQ03");
	}
}

