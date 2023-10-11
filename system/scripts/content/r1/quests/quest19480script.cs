//--- Melia Script -----------------------------------------------------------
// Endless Gluttony (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Julius.
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

[QuestScript(19480)]
public class Quest19480Script : QuestScript
{
	protected override void Load()
	{
		SetId(19480);
		SetName("Endless Gluttony (2)");
		SetDescription("Talk to Pilgrim Julius");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PILGRIM46_SQ_050_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(121));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM46_SQ_040"));

		AddReward(new ExpReward(542808, 542808));
		AddReward(new ItemReward("expCard7", 5));
		AddReward(new ItemReward("Vis", 3025));

		AddDialogHook("PILGRIM46_NPC02", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM46_NPC02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM46_SQ_050_ST", "PILGRIM46_SQ_050", "Give him the music box", "Something's not right. Don't show it"))
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

		await dialog.Msg("PILGRIM46_SQ_050_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

