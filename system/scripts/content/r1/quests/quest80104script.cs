//--- Melia Script -----------------------------------------------------------
// Earth Energy
//--- Description -----------------------------------------------------------
// Quest to Talk to Kabbalist Lutas.
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

[QuestScript(80104)]
public class Quest80104Script : QuestScript
{
	protected override void Load()
	{
		SetId(80104);
		SetName("Earth Energy");
		SetDescription("Talk to Kabbalist Lutas");

		AddPrerequisite(new LevelPrerequisite(226));
		AddPrerequisite(new CompletedPrerequisite("CORAL_35_2_SQ_5"));

		AddReward(new ExpReward(1623069, 1623069));
		AddReward(new ItemReward("expCard11", 1));
		AddReward(new ItemReward("Vis", 8136));

		AddDialogHook("CORAL_35_2_LUTAS_2", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_35_2_LUTAS_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_35_2_SQ_6_start", "CORAL_35_2_SQ_6", "I'll gather the energy.", "That sounds dangerous"))
		{
			case 1:
				await dialog.Msg("NPCAin/CORAL_35_2_LUTAS_2/bury/1");
				dialog.UnHideNPC("CORAL_35_2_TERRA_MAKING");
				ZoneServer.Instance.World.FindNPC("CORAL_35_2_TERRA_MAKING")?.PlayEffectLocal(character.Connection, "F_pattern015_white", 1f, "BOT");
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

		// Func/CORAL_35_2_SHOCK_WAVE;
		await dialog.Msg("CORAL_35_2_SQ_6_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

