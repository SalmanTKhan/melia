//--- Melia Script -----------------------------------------------------------
// Into the Grip (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Pranas.
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

[QuestScript(60128)]
public class Quest60128Script : QuestScript
{
	protected override void Load()
	{
		SetId(60128);
		SetName("Into the Grip (2)");
		SetDescription("Talk with Priest Pranas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PRISON622_MQ_03_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("PRISON622_MQ_01"));

		AddObjective("kill0", "Kill 1 Fire Lord", new KillObjective(1, MonsterId.Boss_Fireload_Q2));

		AddReward(new ExpReward(40290, 40290));
		AddReward(new ItemReward("expCard2", 3));
		AddReward(new ItemReward("Vis", 294));

		AddDialogHook("PRISON622_PRANAS", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON621_IRMA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON622_MQ_03_01", "PRISON622_MQ_03", "I will go there right away", "Tell me about the legends", "I need to prepare"))
		{
			case 1:
				dialog.UnHideNPC("PRISON621_IRMA");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
			case 2:
				await dialog.Msg("PRISON622_SQ_01_add");
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

