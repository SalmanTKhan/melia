//--- Melia Script -----------------------------------------------------------
// Shard Collection(3)
//--- Description -----------------------------------------------------------
// Quest to Check the Secret Device in the Supply Room.
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

[QuestScript(30180)]
public class Quest30180Script : QuestScript
{
	protected override void Load()
	{
		SetId(30180);
		SetName("Shard Collection(3)");
		SetDescription("Check the Secret Device in the Supply Room");

		AddPrerequisite(new LevelPrerequisite(269));
		AddPrerequisite(new CompletedPrerequisite("PRISON_81_MQ_6"));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("PRISON_81_MQ_7_ITEM", 1));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 11029));

		AddDialogHook("PRISON_81_OBJ_5", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON_81_OBJ_5", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("NPCAin/PRISON_81_OBJ_5/OPEN/1");
		dialog.HideNPC("PRISON_81_NPC_2");
		dialog.UnHideNPC("PRISON_81_NPC_3");
		ZoneServer.Instance.World.FindNPC("PRISON_81_NPC_3")?.PlayEffectLocal(character.Connection, "F_lineup020_blue_mint", 0.6f, "BOT");
		// Func/SCR_PRISON_81_MQ_7_SUCC;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

