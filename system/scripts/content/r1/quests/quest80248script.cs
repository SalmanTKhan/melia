//--- Melia Script -----------------------------------------------------------
// The Secret of the Lake (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Adjutant Bern.
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

[QuestScript(80248)]
public class Quest80248Script : QuestScript
{
	protected override void Load()
	{
		SetId(80248);
		SetName("The Secret of the Lake (3)");
		SetDescription("Talk to Resistance Adjutant Bern");

		AddPrerequisite(new LevelPrerequisite(362));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_85_MQ_05"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 18824));

		AddDialogHook("F_3CMLAKE_85_MQ_06_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_85_MQ_06_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_85_MQ_06_ST", "F_3CMLAKE_85_MQ_06", "Alright", "That's too difficult for me."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_85_MQ_06_AFST");
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

		await dialog.Msg("F_3CMLAKE_85_MQ_06_SU");
		dialog.UnHideNPC("F_3CMLAKE_85_MQ_07_AFTER_EFFECT");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

