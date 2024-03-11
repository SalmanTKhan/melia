//--- Melia Script -----------------------------------------------------------
// Curse of Sloth - Laziness
//--- Description -----------------------------------------------------------
// Quest to Observe the Indolent Tree Root Crystal.
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

[QuestScript(19550)]
public class Quest19550Script : QuestScript
{
	protected override void Load()
	{
		SetId(19550);
		SetName("Curse of Sloth - Laziness");
		SetDescription("Observe the Indolent Tree Root Crystal");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PILGRIM47_SQ_010_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(124));

		AddObjective("kill0", "Kill 3 Jewel of Prominence(s)", new KillObjective(3, MonsterId.Spell_Crystal_Gem_Red));

		AddReward(new ExpReward(361872, 361872));
		AddReward(new ItemReward("expCard7", 4));
		AddReward(new ItemReward("Vis", 3100));

		AddDialogHook("PILGRIM47_CRYST01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM47_CRYST01", "BeforeEnd", BeforeEnd);
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

		dialog.HideNPC("PILGRIM47_CRYST01");
		dialog.HideNPC("PILGRIM47_CURSE01");
		await Task.Delay(5000);
		// Func/SCR_PILGRIM47_CRYST01_EXPLOSION_TRACK_PLAY;
		await Task.Delay(5000);
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Successfully destroyed Tree Root Crystal! {nl}The curse laid around will disappear!");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

