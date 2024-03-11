//--- Melia Script -----------------------------------------------------------
// Farewell, My Friend (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Orville.
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

[QuestScript(20327)]
public class Quest20327Script : QuestScript
{
	protected override void Load()
	{
		SetId(20327);
		SetName("Farewell, My Friend (3)");
		SetDescription("Talk to Pilgrim Orville");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PILGRIMROAD55_SQ10_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(144));
		AddPrerequisite(new CompletedPrerequisite("PILGRIMROAD55_SQ09"));

		AddObjective("kill0", "Kill 8 Red Infro Hoglan(s) or Red Infro Blood(s)", new KillObjective(8, 57368, 57369));

		AddReward(new ExpReward(852900, 852900));
		AddReward(new ItemReward("expCard8", 4));
		AddReward(new ItemReward("Vis", 3744));

		AddDialogHook("PILGRIMROAD55_SQ09", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIMROAD55_SQ11", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIMROAD55_SQ10_select01", "PILGRIMROAD55_SQ10", "I will be with him", "I will leave now"))
		{
			case 1:
				await dialog.Msg("FadeOutIN/1000");
				dialog.HideNPC("PILGRIMROAD55_SQ09");
				dialog.HideNPC("PRIST_DEAD_BODY_AFTER");
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

		await dialog.Msg("PILGRIMROAD55_SQ10_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

