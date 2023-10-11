//--- Melia Script -----------------------------------------------------------
// Waters Post (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pajauta.
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

[QuestScript(60403)]
public class Quest60403Script : QuestScript
{
	protected override void Load()
	{
		SetId(60403);
		SetName("Waters Post (3)");
		SetDescription("Talk to Pajauta");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PAYAUTA_EP11_4_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(380));
		AddPrerequisite(new CompletedPrerequisite("PAYAUTA_EP11_3"));

		AddObjective("kill0", "Kill 8 Beissen(s) or Kindron Shooter(s) or Kindron Boor(s)", new KillObjective(8, 59078, 59152, 59108));

		AddReward(new ItemReward("expCard16", 1));
		AddReward(new ItemReward("Vis", 20140));

		AddDialogHook("PAYAUTA_EP11_NPC_87", "BeforeStart", BeforeStart);
		AddDialogHook("PAJAUTA_FOLLOWNPC_AI_4_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PAYAUTA_EP11_4_1", "PAYAUTA_EP11_4", "Let's go.", "Please wait"))
		{
			case 1:
				await dialog.Msg("FadeOutIN/3000");
				dialog.HideNPC("PAYAUTA_EP11_NPC_87");
				await Task.Delay(500);
				// Func/PAJAUTA_FOLLOWNPC_LIB/PAYAUTA_EP11_4;
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

		await dialog.Msg("PAYAUTA_EP11_4_3");
		// Func/PAJAUTA_FOLLOWNPC_LIB_CANCEL;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

