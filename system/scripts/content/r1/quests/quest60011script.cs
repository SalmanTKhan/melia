//--- Melia Script -----------------------------------------------------------
// Lodged Stone
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Arune.
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

[QuestScript(60011)]
public class Quest60011Script : QuestScript
{
	protected override void Load()
	{
		SetId(60011);
		SetName("Lodged Stone");
		SetDescription("Talk to Kupole Arune");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "VPRISON512_MQ_05_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(154));
		AddPrerequisite(new CompletedPrerequisite("VPRISON512_MQ_04"), new CompletedPrerequisite("VPRISON512_MQ_01"), new CompletedPrerequisite("VPRISON512_MQ_02"), new CompletedPrerequisite("VPRISON512_MQ_03"));

		AddObjective("kill0", "Kill 1 Demon Lord Nuaele", new KillObjective(1, MonsterId.Boss_Nuaelle));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 9));
		AddReward(new ItemReward("Vis", 31262));

		AddDialogHook("VPRISON512_MQ_NORGAILE", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON512_MQ_NORGAILE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("VPRISON512_MQ_05_01", "VPRISON512_MQ_05", "I am ready", "I need to prepare"))
		{
			case 1:
				dialog.UnHideNPC("VPRISON512_MQ_ALDONA");
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

		await dialog.Msg("VPRISON512_MQ_05_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

