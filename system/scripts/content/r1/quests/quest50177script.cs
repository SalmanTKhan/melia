//--- Melia Script -----------------------------------------------------------
// Cursed Statues (2)
//--- Description -----------------------------------------------------------
// Quest to Destroy the Cursed Statues with the Purification Sphere.
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

[QuestScript(50177)]
public class Quest50177Script : QuestScript
{
	protected override void Load()
	{
		SetId(50177);
		SetName("Cursed Statues (2)");
		SetDescription("Destroy the Cursed Statues with the Purification Sphere");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "TABLELAND_73_SQ2_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(250));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_73_SQ1"));

		AddObjective("kill0", "Kill 5 White Wendigo Searcher(s) or Blue Hohen Gulak(s) or Blue Tini Archer(s)", new KillObjective(5, 57873, 57977, 57906));

		AddReward(new ExpReward(5910366, 5910366));
		AddReward(new ItemReward("expCard12", 2));
		AddReward(new ItemReward("Vis", 10000));

		AddDialogHook("TABLE73_SUB_ARTIFACT1", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE73_SUB_ARTIFACT1", "BeforeEnd", BeforeEnd);
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

		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You destroyed the cursed statue!");
		// Func/TABLE73_SUBQ1_COMPLETE;
		ZoneServer.Instance.World.FindNPC("TABLE73_SUB_ARTIFACT1")?.PlayEffectLocal(character.Connection, "F_explosion098_dark_blue", 1f, "BOT");
		await dialog.Msg("NPCAin/TABLE73_SUB_ARTIFACT1/DEAD/0");
		dialog.HideNPC("TABLE73_SUB_ARTIFACT1");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You destroyed the cursed statue.");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

