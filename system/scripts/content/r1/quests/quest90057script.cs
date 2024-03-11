//--- Melia Script -----------------------------------------------------------
// Full of Evil Energy
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

[QuestScript(90057)]
public class Quest90057Script : QuestScript
{
	protected override void Load()
	{
		SetId(90057);
		SetName("Full of Evil Energy");
		SetDescription("Talk to Dievdirbys Asel");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "KATYN_45_3_SQ_3_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(253));
		AddPrerequisite(new CompletedPrerequisite("KATYN_45_3_SQ_2"));

		AddObjective("kill0", "Kill 1 Iltiswort", new KillObjective(1, MonsterId.Boss_Iltiswort_Q2));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("KATYN_45_3_SQ_3_ITEM1", 1));
		AddReward(new ItemReward("KATYN_45_3_SQ_3_ITEM2", 1));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 10120));

		AddDialogHook("KATYN_45_3_AJEL3", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_3_GRASS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_45_3_SQ_3_ST", "KATYN_45_3_SQ_3", "I'll go there", "That sounds dangerous"))
		{
			case 1:
				await dialog.Msg("KATYN_45_3_SQ_3_AG");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		ZoneServer.Instance.World.FindNPC("KATYN_45_3_GRASS")?.PlayEffectLocal(character.Connection, "I_smoke013_dark1", 2f, "MID");
		dialog.HideNPC("KATYN_45_3_GRASS");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

