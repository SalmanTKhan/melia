//--- Melia Script -----------------------------------------------------------
// The Incident That Happened Here (1)
//--- Description -----------------------------------------------------------
// Quest to Search the soldiers' post.
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

[QuestScript(80054)]
public class Quest80054Script : QuestScript
{
	protected override void Load()
	{
		SetId(80054);
		SetName("The Incident That Happened Here (1)");
		SetDescription("Search the soldiers' post");

		AddPrerequisite(new LevelPrerequisite(208));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_11_1_SQ_02"));

		AddDialogHook("TABLELAND_11_1_SQ_03_TRACE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("BalloonText/TABLELAND_11_1_SQ_03_END/5");
		ZoneServer.Instance.World.FindNPC("TABLELAND_11_1_SQ_03_TRACE")?.PlayEffectLocal(character.Connection, "I_smoke_red2", 2f, "BOT");
		await Task.Delay(1000);
		dialog.HideNPC("TABLELAND_11_1_SQ_03_TRACE");
		await Task.Delay(3000);
		// Func/TABLELAND_11_1_SQ_04_SOUND;
		await dialog.Msg("BalloonText/TABLELAND_11_1_SQ_04_START/3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

