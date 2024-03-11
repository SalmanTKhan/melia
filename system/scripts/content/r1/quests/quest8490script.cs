//--- Melia Script -----------------------------------------------------------
// Mage Tower 4th Floor (3)
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

[QuestScript(8490)]
public class Quest8490Script : QuestScript
{
	protected override void Load()
	{
		SetId(8490);
		SetName("Mage Tower 4th Floor (3)");
		SetDescription("Talk to Grita");

		AddPrerequisite(new LevelPrerequisite(123));
		AddPrerequisite(new CompletedPrerequisite("FTOWER44_MQ_02"));

		AddReward(new ExpReward(690268, 690268));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 5));
		AddReward(new ItemReward("FTOWER_FIRE_ESSENCE_2", 1));
		AddReward(new ItemReward("Vis", 3075));

		AddDialogHook("FTOWER44_G_AI", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER44_G_AI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FTOWER44_MQ_03_01", "FTOWER44_MQ_03", "I'll collect the Flame Crystals", "It will be enough this way"))
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

		await dialog.Msg("FTOWER44_MQ_03_03");
		await dialog.Msg("CameraShockWaveLocal/2/99999/10/2/200/0");
		await Task.Delay(2000);
		await dialog.Msg("FTOWER44_MQ_03_04");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

