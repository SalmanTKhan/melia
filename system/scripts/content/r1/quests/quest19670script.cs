//--- Melia Script -----------------------------------------------------------
// Offering to the Angry Souls
//--- Description -----------------------------------------------------------
// Quest to Souls of the Altar.
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

[QuestScript(19670)]
public class Quest19670Script : QuestScript
{
	protected override void Load()
	{
		SetId(19670);
		SetName("Offering to the Angry Souls");
		SetDescription("Souls of the Altar");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PILGRIM50_SQ_060_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(127));

		AddObjective("kill0", "Kill 20 Kodomor(s) or Lomor(s) or Prison Fighter(s)", new KillObjective(20, 41450, 57403, 41315));

		AddReward(new ExpReward(361872, 361872));
		AddReward(new ItemReward("expCard7", 4));
		AddReward(new ItemReward("Vis", 3175));

		AddDialogHook("PILGRIM50_ANGRY02", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM50_GHOST2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("PILGRIM50_SQ_060_COMP");
		ZoneServer.Instance.World.FindNPC("PILGRIM50_GHOST2")?.PlayEffectLocal(character.Connection, "I_bomb005_dark", 1f, "BOT");
		await dialog.Msg("FadeOutIN/1000");
		dialog.HideNPC("PILGRIM50_GHOST2");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Calmed the soul!");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

