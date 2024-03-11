//--- Melia Script -----------------------------------------------------------
// Signal
//--- Description -----------------------------------------------------------
// Quest to Talk with Member Irmantas.
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

[QuestScript(60043)]
public class Quest60043Script : QuestScript
{
	protected override void Load()
	{
		SetId(60043);
		SetName("Signal");
		SetDescription("Talk with Member Irmantas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PILGRIM311_SQ_01_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 8 Ellomago(s)", new KillObjective(8, MonsterId.Sec_Ellomago));

		AddReward(new ExpReward(205740, 205740));
		AddReward(new ItemReward("expCard5", 5));
		AddReward(new ItemReward("Vis", 1640));

		AddDialogHook("PILGRIM311_IRMANTAS_01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM311_IRMANTAS_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM311_SQ_01_01", "PILGRIM311_SQ_01", "Shoot. I will help. ", "Let's not do dangerous stuff"))
		{
			case 1:
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

