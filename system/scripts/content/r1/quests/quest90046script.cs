//--- Melia Script -----------------------------------------------------------
// Once Again, Purification (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Dievdirbys Asel.
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

[QuestScript(90046)]
public class Quest90046Script : QuestScript
{
	protected override void Load()
	{
		SetId(90046);
		SetName("Once Again, Purification (2)");
		SetDescription("Talk to Dievdirbys Asel");

		AddPrerequisite(new LevelPrerequisite(249));
		AddPrerequisite(new CompletedPrerequisite("KATYN_45_2_SQ_4"));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 9213));

		AddDialogHook("KATYN_45_2_AJEL2", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_2_AJEL2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_45_2_SQ_5_ST", "KATYN_45_2_SQ_5", "Leave it to me", "That seems difficult"))
		{
			case 1:
				// Func/SCR_KATYN_45_2_LOOK;
				await dialog.Msg("NPCAin/KATYN_45_2_AJEL2/WORSHIP/1");
				ZoneServer.Instance.World.FindNPC("KATYN_45_2_AJEL2")?.PlayEffectLocal(character.Connection, "F_light012_1", 0.4f, "BOT");
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

		dialog.HideNPC("KATYN_45_2_SQ_5_DARK");
		// Func/SCR_KATYN_45_2_LOOK;
		await dialog.Msg("NPCAin/KATYN_45_2_AJEL2/ABSORB/0");
		await Task.Delay(1000);
		await dialog.Msg("KATYN_45_2_SQ_5_SU");
		dialog.HideNPC("KATYN_45_2_AJEL2");
		await dialog.Msg("FadeOutIN/2000");
		dialog.UnHideNPC("KATYN_45_2_AJEL3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

