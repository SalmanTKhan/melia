//--- Melia Script -----------------------------------------------------------
// Dusk and Dawn (4)
//--- Description -----------------------------------------------------------
// Quest to Return to Goddess Laima.
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

[QuestScript(72263)]
public class Quest72263Script : QuestScript
{
	protected override void Load()
	{
		SetId(72263);
		SetName("Dusk and Dawn (4)");
		SetDescription("Return to Goddess Laima");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "EP12_FINALE_04_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(446));
		AddPrerequisite(new CompletedPrerequisite("EP12_FINALE_03"));

		AddObjective("kill0", "Kill 1 Glutton Kabad", new KillObjective(1, MonsterId.Boss_Kabad_Q1));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("Vis", 26314));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 17));

		AddDialogHook("EP12_FINALE_DIRECTION_TRIGGER", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_MAINSTREAM_NERINGA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("EP12_FINALE_04_DLG13");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.HideNPC("EP12_FINALE_RAIMA01");
	}
}

