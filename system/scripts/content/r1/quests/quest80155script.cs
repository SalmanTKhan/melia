//--- Melia Script -----------------------------------------------------------
// They Hid Her (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Medena.
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

[QuestScript(80155)]
public class Quest80155Script : QuestScript
{
	protected override void Load()
	{
		SetId(80155);
		SetName("They Hid Her (5)");
		SetDescription("Talk to Kupole Medena");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "LIMESTONE_52_4_MQ_7_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(298));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_4_MQ_6"));

		AddObjective("kill0", "Kill 2 Flammidus(s) or Riteris(s)", new KillObjective(2, 107014, 107015));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 4));
		AddReward(new ItemReward("Vis", 12516));

		AddDialogHook("LIMESTONECAVE_52_4_MEDENA_AI", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONECAVE_52_4_MEDENA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_4_MQ_7_start", "LIMESTONE_52_4_MQ_7", "Let's go", "Just wait a while."))
		{
			case 1:
				// Func/LIMESTONE_52_4_REENTER_RUN;
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

		dialog.UnHideNPC("LIMESTONECAVE_52_4_MEDENA_2");
		dialog.HideNPC("LIMESTONECAVE_52_4_MEDENA");
		ZoneServer.Instance.World.FindNPC("LIMESTONECAVE_52_4_MEDENA")?.PlayEffectLocal(character.Connection, "F_burstup024_dark", 2f, "BOT");
		await dialog.Msg("LIMESTONE_52_4_MQ_7_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

