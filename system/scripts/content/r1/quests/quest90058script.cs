//--- Melia Script -----------------------------------------------------------
// Dangerous Dagger
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

[QuestScript(90058)]
public class Quest90058Script : QuestScript
{
	protected override void Load()
	{
		SetId(90058);
		SetName("Dangerous Dagger");
		SetDescription("Talk to Dievdirbys Asel");

		AddPrerequisite(new LevelPrerequisite(253));
		AddPrerequisite(new CompletedPrerequisite("KATYN_45_3_SQ_3"));
		AddPrerequisite(new ItemPrerequisite("KATYN_45_3_SQ_3_ITEM1", -100), new ItemPrerequisite("KATYN_45_3_SQ_3_ITEM2", -100), new ItemPrerequisite("KATYN_45_2_SQ_5_ITEM", -100));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 10120));

		AddDialogHook("KATYN_45_3_AJEL3", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_DIEVDIRBYS2_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_45_3_SQ_4_ST", "KATYN_45_3_SQ_4", "I'll go and ask for help.", "It's too far away"))
		{
			case 1:
				await dialog.Msg("KATYN_45_3_SQ_4_AG");
				dialog.UnHideNPC("KATYN_45_3_SCULPT3");
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

		await dialog.Msg("KATYN_45_3_SQ_4_SU");
		ZoneServer.Instance.World.FindNPC("JOB_DIEVDIRBYS2_NPC")?.PlayEffectLocal(character.Connection, "F_light008", 0.5f, "MID");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

