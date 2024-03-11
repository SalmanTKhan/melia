//--- Melia Script -----------------------------------------------------------
// The Final Battle (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Commander Byle.
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

[QuestScript(72211)]
public class Quest72211Script : QuestScript
{
	protected override void Load()
	{
		SetId(72211);
		SetName("The Final Battle (3)");
		SetDescription("Talk to Resistance Commander Byle");

		AddPrerequisite(new LevelPrerequisite(386));
		AddPrerequisite(new CompletedPrerequisite("STARTOWER_92_MQ_20"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 4));
		AddReward(new ItemReward("Vis", 20458));

		AddDialogHook("D_STARTOWER_92_RESISTANCE_LEADER_BAYL_02", "BeforeStart", BeforeStart);
		AddDialogHook("D_STARTOWER_92_RESISTANCE_LEADER_BAYL_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("STARTOWER_92_MQ_30_DLG1", "STARTOWER_92_MQ_30", "Alright", "I need time to rest."))
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

		await dialog.Msg("STARTOWER_92_MQ_30_DLG3");
		dialog.HideNPC("D_STARTOWER_92_VALNIAS_DEVICE");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

