//--- Melia Script -----------------------------------------------------------
// Lunatic Wizard (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Grita.
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

[QuestScript(8485)]
public class Quest8485Script : QuestScript
{
	protected override void Load()
	{
		SetId(8485);
		SetName("Lunatic Wizard (3)");
		SetDescription("Talk to Grita");

		AddPrerequisite(new LevelPrerequisite(119));
		AddPrerequisite(new CompletedPrerequisite("FTOWER43_MQ_02"));

		AddReward(new ExpReward(690268, 690268));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 5));
		AddReward(new ItemReward("Vis", 2856));

		AddDialogHook("FTOWER43_G_AI", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER43_G_AI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FTOWER43_MQ_03_01", "FTOWER43_MQ_03", "I'll find the data", "Let's just get up there quickly!"))
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

		await dialog.Msg("FTOWER43_MQ_03_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FTOWER43_MQ_07");
	}
}

