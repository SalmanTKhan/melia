//--- Melia Script -----------------------------------------------------------
// Unbreakable Barrier
//--- Description -----------------------------------------------------------
// Quest to Talk to Revelator Mihail.
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

[QuestScript(70442)]
public class Quest70442Script : QuestScript
{
	protected override void Load()
	{
		SetId(70442);
		SetName("Unbreakable Barrier");
		SetDescription("Talk to Revelator Mihail");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SCR_CASTLE65_3_MQ03_TRACKSTART", "None");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("CASTLE65_3_MQ02"));

		AddObjective("kill0", "Kill 10 Pag Emitter(s)", new KillObjective(10, MonsterId.PagEmitter));

		AddReward(new ExpReward(245710, 245710));
		AddReward(new ItemReward("expCard5", 2));
		AddReward(new ItemReward("Vis", 1680));

		AddDialogHook("CASTLE653_MQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE653_MQ_04_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE653_MQ_03_start", "CASTLE65_3_MQ03", "Let's hurry", "Let's catch our breath for a while"))
		{
			case 1:
				// Func/SCR_CASTLE653_MQ_03_P;
				await dialog.Msg("FadeOutIN/1000");
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


		return HookResult.Break;
	}
}

