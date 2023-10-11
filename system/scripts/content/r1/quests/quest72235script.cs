//--- Melia Script -----------------------------------------------------------
// Last Man Standing
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Adjutant Antanina.
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

[QuestScript(72235)]
public class Quest72235Script : QuestScript
{
	protected override void Load()
	{
		SetId(72235);
		SetName("Last Man Standing");
		SetDescription("Talk to Resistance Adjutant Antanina");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "CASTLE95_MAIN06_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(398));
		AddPrerequisite(new CompletedPrerequisite("CASTLE95_MAIN05"));
		AddPrerequisite(new ItemPrerequisite("CASTLE95_MAIN02_BOOK", -100));

		AddObjective("kill0", "Kill 1 Demon Lord Moringponia", new KillObjective(1, MonsterId.Boss_Moringponia_Q1));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("Vis", 21041));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("CASTLE95_NPC_MAIN02", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE95_NPC_MAIN02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE95_MAIN06_01", "CASTLE95_MAIN06", "Let's go.", "I need to rest."))
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

		await dialog.Msg("CASTLE95_MAIN06_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

