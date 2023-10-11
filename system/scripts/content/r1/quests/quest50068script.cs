//--- Melia Script -----------------------------------------------------------
// To the Storage Quarter (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Old Manager.
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

[QuestScript(50068)]
public class Quest50068Script : QuestScript
{
	protected override void Load()
	{
		SetId(50068);
		SetName("To the Storage Quarter (2)");
		SetDescription("Talk to the Old Manager");

		AddPrerequisite(new LevelPrerequisite(207));
		AddPrerequisite(new CompletedPrerequisite("UNDERFORTRESS_67_MQ050"));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 24));
		AddReward(new ItemReward("Vis", 65205));

		AddDialogHook("EMINENT_67_1", "BeforeStart", BeforeStart);
		AddDialogHook("EMINENT_68_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("UNDER_67_MQ060_startnp01", "UNDERFORTRESS_67_MQ060", "Alright", "Tell him to go there later"))
		{
			case 1:
				await dialog.Msg("UNDER_67_MQ060_startnp02");
				dialog.HideNPC("EMINENT_67_1");
				await dialog.Msg("FadeOutIN/1000");
				// Func/UNDER67_MQ06_AI;
				dialog.UnHideNPC("EMINENT_68_1");
				character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Leave the message that is written with the method to make the certificate");
				dialog.UnHideNPC("UNDER67_MQ060");
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

		await dialog.Msg("UNDER_67_MQ050_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

