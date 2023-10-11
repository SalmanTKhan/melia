//--- Melia Script -----------------------------------------------------------
// Fainted or Asleep? (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Dievdirbys Asel.
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

[QuestScript(90047)]
public class Quest90047Script : QuestScript
{
	protected override void Load()
	{
		SetId(90047);
		SetName("Fainted or Asleep? (1)");
		SetDescription("Talk to Dievdirbys Asel");

		AddPrerequisite(new LevelPrerequisite(249));
		AddPrerequisite(new CompletedPrerequisite("KATYN_45_2_SQ_5"));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 9213));

		AddDialogHook("KATYN_45_2_AJEL3", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_2_AJEL3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_45_2_SQ_6_ST", "KATYN_45_2_SQ_6", "Ask what you should do", "I'm going to rest for a while."))
		{
			case 1:
				await dialog.Msg("KATYN_45_2_SQ_6_AG");
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

		await dialog.Msg("KATYN_45_2_SQ_6_SU");
		// Func/SCR_KATYN_45_2_LOOK;
		await dialog.Msg("NPCAin/KATYN_45_2_AJEL3/ABSORB/0");
		await Task.Delay(1500);
		ZoneServer.Instance.World.FindNPC("KATYN_45_2_OWL4")?.PlayEffectLocal(character.Connection, "F_light018_yellow", 2f, "MID");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

