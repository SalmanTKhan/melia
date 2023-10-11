//--- Melia Script -----------------------------------------------------------
// The Fugitive's Dream (8)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Grisia.
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

[QuestScript(60305)]
public class Quest60305Script : QuestScript
{
	protected override void Load()
	{
		SetId(60305);
		SetName("The Fugitive's Dream (8)");
		SetDescription("Talk to Kupole Grisia");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "DCAPITAL107_SQ_8_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(378));
		AddPrerequisite(new CompletedPrerequisite("DCAPITAL107_SQ_7"));

		AddObjective("kill0", "Kill 1 Banshee Boss", new KillObjective(1, MonsterId.Boss_Banshee_Q2));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 39000));
		AddReward(new ItemReward("misc_ore15", 2));

		AddDialogHook("DCAPITAL107_GRISIA_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL107_GRISIA_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("DCAPITAL107_SQ_8_1", "DCAPITAL107_SQ_8", "I am ready", "I need to prepare"))
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

		await dialog.Msg("DCAPITAL107_SQ_8_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

