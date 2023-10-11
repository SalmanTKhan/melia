//--- Melia Script -----------------------------------------------------------
// 3 numbers are the secret of the pillar
//--- Description -----------------------------------------------------------
// Quest to Look at the pillar.
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

[QuestScript(40970)]
public class Quest40970Script : QuestScript
{
	protected override void Load()
	{
		SetId(40970);
		SetName("3 numbers are the secret of the pillar");
		SetDescription("Look at the pillar");

		AddPrerequisite(new LevelPrerequisite(103));

		AddReward(new ExpReward(221139, 221139));
		AddReward(new ItemReward("expCard6", 5));
		AddReward(new ItemReward("Vis", 2472));

		AddDialogHook("ROKAS_36_1_PILLA03", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS_36_1_PILLA03", "BeforeEnd", BeforeEnd);
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

		ZoneServer.Instance.World.FindNPC("ROKAS_36_1_PILLA03")?.PlayEffectLocal(character.Connection, "F_ground139_light_green", 1f, "BOT");
		await dialog.Msg("ROKAS_36_1_SQ_030_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

