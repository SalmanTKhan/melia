//--- Melia Script -----------------------------------------------------------
// Securing the Entrance (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pajauta.
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

[QuestScript(91136)]
public class Quest91136Script : QuestScript
{
	protected override void Load()
	{
		SetId(91136);
		SetName("Securing the Entrance (2)");
		SetDescription("Talk to Pajauta");

		AddPrerequisite(new LevelPrerequisite(470));
		AddPrerequisite(new CompletedPrerequisite("EP14_2_DCASTLE1_MQ_2"));

		AddObjective("kill0", "Kill 10 Blickferret Spearman(s) or Blickferret Fighter(s) or Blickferret Shielder(s) or Blickferret Swordsman(s)", new KillObjective(10, 59740, 59741, 59743, 59742));

		AddReward(new ExpReward(1200000000, 1200000000));
		AddReward(new ItemReward("Vis", 30245));

		AddDialogHook("EP14_2_1_PAJAUTA1", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_2_1_PAJAUTA1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_2_DCASTLE1_MQ_3_DLG1", "EP14_2_DCASTLE1_MQ_3", "Alright", "I need to do other thing right now."))
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

		await dialog.Msg("EP14_2_DCASTLE1_MQ_3_DLG3");
		dialog.UnHideNPC("EP14_2_1_Lamin1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

