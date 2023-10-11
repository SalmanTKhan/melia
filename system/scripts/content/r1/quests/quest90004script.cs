//--- Melia Script -----------------------------------------------------------
// The Corrupted Lake (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Elder Aloizard.
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

[QuestScript(90004)]
public class Quest90004Script : QuestScript
{
	protected override void Load()
	{
		SetId(90004);
		SetName("The Corrupted Lake (5)");
		SetDescription("Talk to Elder Aloizard");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_83_MQ_03"));

		AddReward(new ExpReward(368565, 368565));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 11115));

		AddDialogHook("3CMLAKE_83_OLDMAN3", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_83_OLDMAN2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("3CMLAKE_83_MQ_04_DLG_01", "F_3CMLAKE_83_MQ_04", "I will check it", "I can't see any more accidents"))
		{
			case 1:
				await dialog.Msg("3CMLAKE_83_MQ_04_DLG_02");
				dialog.HideNPC("3CMLAKE_83_OLDMAN3");
				dialog.HideNPC("3CMLAKE_83_PEOPLE4");
				await dialog.Msg("FadeOutIN/3000");
				dialog.UnHideNPC("3CMLAKE_83_OLDMAN2");
				dialog.UnHideNPC("3CMLAKE_83_PEOPLE6");
				character.Quests.Start(this.QuestId);
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

