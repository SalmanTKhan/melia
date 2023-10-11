//--- Melia Script -----------------------------------------------------------
// Business Interference (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Technician Heinen.
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

[QuestScript(4415)]
public class Quest4415Script : QuestScript
{
	protected override void Load()
	{
		SetId(4415);
		SetName("Business Interference (2)");
		SetDescription("Talk to Technician Heinen");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS27_QB_3_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(67));
		AddPrerequisite(new CompletedPrerequisite("ROKAS27_QB_2"));

		AddObjective("kill0", "Kill 1 Canyon Area Device 7", new KillObjective(1, MonsterId.Npc_Rokas_Cube));

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Drug_SP2_Q", 30));
		AddReward(new ItemReward("Vis", 1273));

		AddDialogHook("ROKAS27_HEINEN", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS27_HEINEN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS27_QB_3_select1", "ROKAS27_QB_3", "Accept the suggestion", "About the strange barrier", "I don't need it"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
			case 2:
				await dialog.Msg("ROKAS27_QB_3_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("ROKAS27_QB_3_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

