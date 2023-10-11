//--- Melia Script -----------------------------------------------------------
// The Hidden Demon Lord
//--- Description -----------------------------------------------------------
// Quest to Talk to the Beholder.
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

[QuestScript(72106)]
public class Quest72106Script : QuestScript
{
	protected override void Load()
	{
		SetId(72106);
		SetName("The Hidden Demon Lord");
		SetDescription("Talk to the Beholder");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_3CMLAKE261_SQ07_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(333));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE261_SQ06"));

		AddObjective("kill0", "Kill 6 Kindron Weilder(s) or Kindron Reilter(s) or Lavisher Mage(s) or Lavisher(s)", new KillObjective(6, 58832, 58833, 58834, 58835));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15651));

		AddDialogHook("3CMLAKE_BLACKMAN02", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_BLACKMAN03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("3CMLAKE261_SQ07_DLG01", "F_3CMLAKE261_SQ07", "I'll go check it out.", "Let's investigate the other side."))
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

		await dialog.Msg("3CMLAKE261_SQ07_DLG03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

