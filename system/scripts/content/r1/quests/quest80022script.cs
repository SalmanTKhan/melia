//--- Melia Script -----------------------------------------------------------
// Ferret-Controlling Totem
//--- Description -----------------------------------------------------------
// Quest to Talk to the Village Headman.
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

[QuestScript(80022)]
public class Quest80022Script : QuestScript
{
	protected override void Load()
	{
		SetId(80022);
		SetName("Ferret-Controlling Totem");
		SetDescription("Talk to the Village Headman");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ORCHARD_323_MQ_05_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_323_MQ_04"));

		AddObjective("kill0", "Kill 1 Vubbe Tribe Flag", new KillObjective(1, MonsterId.Bube_Flag1));

		AddReward(new ExpReward(614275, 614275));
		AddReward(new ItemReward("expCard6", 5));
		AddReward(new ItemReward("Vis", 20240));

		AddDialogHook("ORCHARD323_MAYOR", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD323_MAYOR", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORCHARD_323_MQ_05_start", "ORCHARD_323_MQ_05", "I'll destroy the totems", "I'll refuse"))
		{
			case 1:
				await dialog.Msg("ORCHARD_323_MQ_05_AG");
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

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ORCHARD_323_MQ_06");
	}
}

