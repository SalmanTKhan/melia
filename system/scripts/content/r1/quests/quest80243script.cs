//--- Melia Script -----------------------------------------------------------
// Hindrance
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Soldier Molan.
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

[QuestScript(80243)]
public class Quest80243Script : QuestScript
{
	protected override void Load()
	{
		SetId(80243);
		SetName("Hindrance");
		SetDescription("Talk to Resistance Soldier Molan");

		AddPrerequisite(new LevelPrerequisite(362));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_85_MQ_01"), new CompletedPrerequisite("F_3CMLAKE_85_MQ_02"));

		AddObjective("kill0", "Kill 6 Lotuscat(s) or Pate(s) or Kindron Leader(s) or Coterie(s) or Trippy(s)", new KillObjective(6, 59070, 59071, 59107, 59072, 59120));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 18824));

		AddDialogHook("F_3CMLAKE_85_MQ_02_2_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_85_MQ_02_2_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_85_MQ_02_2_ST", "F_3CMLAKE_85_MQ_02_2", "Don't worry.", "I'm too afraid to go alone."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_85_MQ_02_2_AFST");
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

		await dialog.Msg("F_3CMLAKE_85_MQ_02_2_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

