//--- Melia Script -----------------------------------------------------------
// Weakening Aura (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Alena.
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

[QuestScript(80127)]
public class Quest80127Script : QuestScript
{
	protected override void Load()
	{
		SetId(80127);
		SetName("Weakening Aura (2)");
		SetDescription("Talk to Kupole Alena");

		AddPrerequisite(new LevelPrerequisite(291));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_2_MQ_1"));

		AddObjective("kill0", "Kill 10 Tala Archer(s) or Green Flamme(s) or Tala Battle Boss(s)", new KillObjective(10, 58434, 58469, 58435));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 12222));

		AddDialogHook("LIMESTONE_52_2_ALLENA", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONE_52_2_ALLENA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_2_MQ_2_start", "LIMESTONE_52_2_MQ_2", "Alright", "Please wait."))
		{
			case 1:
				// Func/LIMESTONE_52_2_REENTER_RUN;
				await dialog.Msg("LIMESTONE_52_2_MQ_2_agree");
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

		ZoneServer.Instance.World.FindNPC("LIMESTONE_52_2_ALLENA")?.PlayEffectLocal(character.Connection, "F_burstup024_dark", 4f, "BOT");
		dialog.HideNPC("LIMESTONE_52_2_DARKWALL");
		await dialog.Msg("LIMESTONE_52_2_MQ_2_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

