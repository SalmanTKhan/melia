//--- Melia Script -----------------------------------------------------------
// Corrupted Lantern (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Guardian Stone Statue.
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

[QuestScript(8439)]
public class Quest8439Script : QuestScript
{
	protected override void Load()
	{
		SetId(8439);
		SetName("Corrupted Lantern (1)");
		SetDescription("Talk to the Guardian Stone Statue");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ZACHA3F_SQ_02_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(88));

		AddObjective("kill0", "Kill 1 Royal Mausoleum Stone Lantern", new KillObjective(1, MonsterId.Npc_Zachariel_Lantern));

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 1760));

		AddDialogHook("ZACHA3F_SQ02_GUARD", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ZACHA3F_SQ_02_01", "ZACHA3F_SQ_02", "Destroy the corrupted lanterns", "I'll wait a little bit"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ZACHA3F_SQ_03");
	}
}

