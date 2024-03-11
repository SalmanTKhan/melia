//--- Melia Script -----------------------------------------------------------
// Messenger Running Away
//--- Description -----------------------------------------------------------
// Quest to Speak with Mardas.
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

[QuestScript(30049)]
public class Quest30049Script : QuestScript
{
	protected override void Load()
	{
		SetId(30049);
		SetName("Messenger Running Away");
		SetDescription("Speak with Mardas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "KATYN_10_MQ_01_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 5 Digo(s)", new KillObjective(5, MonsterId.Digo));

		AddReward(new ExpReward(42210, 42210));
		AddReward(new ItemReward("expCard3", 1));
		AddReward(new ItemReward("Vis", 1026));

		AddDialogHook("KATYN_10_NPC_01", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_10_NPC_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_10_MQ_01_select", "KATYN_10_MQ_01", "I'm curious, I'll have a look", "Chicken out"))
		{
			case 1:
				await dialog.Msg("KATYN_10_MQ_01_agree");
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

