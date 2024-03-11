//--- Melia Script -----------------------------------------------------------
// The Closing Dragnet (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Auguste Dupin.
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

[QuestScript(50395)]
public class Quest50395Script : QuestScript
{
	protected override void Load()
	{
		SetId(50395);
		SetName("The Closing Dragnet (2)");
		SetDescription("Talk to Auguste Dupin");

		AddPrerequisite(new LevelPrerequisite(384));
		AddPrerequisite(new CompletedPrerequisite("F_NICOPOLIS_81_2_SQ_08"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 21000));

		AddDialogHook("NICO812_SUBQ_NPC2", "BeforeStart", BeforeStart);
		AddDialogHook("NICO812_SUBQ_NPC2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("NICOPOLIS812_SQ09_START1", "F_NICOPOLIS_81_2_SQ_09", "Interrogate.", "Leave this place"))
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

		await dialog.Msg("NICOPOLIS812_SQ09_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

