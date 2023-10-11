//--- Melia Script -----------------------------------------------------------
// Security Guard's Favor
//--- Description -----------------------------------------------------------
// Quest to Talk to the Guard.
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

[QuestScript(50384)]
public class Quest50384Script : QuestScript
{
	protected override void Load()
	{
		SetId(50384);
		SetName("Security Guard's Favor");
		SetDescription("Talk to the Guard");

		AddPrerequisite(new LevelPrerequisite(381));

		AddObjective("kill0", "Kill 20 Crescent Moya(s) or Mimorat Purple(s) or Mimorat Green(s) or Haunted House(s)", new KillObjective(20, 59149, 59156, 59159, 59160));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 20000));

		AddDialogHook("NICO811_NPC3", "BeforeStart", BeforeStart);
		AddDialogHook("NICO811_NPC3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("NICO811_SUBQ6_START", "F_NICOPOLIS_81_1_SQ_06", "I'll help you defeat the monsters.", "Leave this place"))
		{
			case 1:
				await dialog.Msg("NICO811_SUBQ6_AGREE1");
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

		await dialog.Msg("NICO811_SUBQ6_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

