//--- Melia Script -----------------------------------------------------------
// Cursed Statues (4)
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

[QuestScript(50179)]
public class Quest50179Script : QuestScript
{
	protected override void Load()
	{
		SetId(50179);
		SetName("Cursed Statues (4)");
		SetDescription("Destroy the Cursed Statues with the Purification Sphere");

		AddPrerequisite(new LevelPrerequisite(250));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_73_SQ3"));

		AddObjective("kill0", "Kill 11 White Wendigo Searcher(s) or Blue Tini Archer(s) or Blue Hohen Gulak(s)", new KillObjective(11, 57873, 57906, 57977));

		AddReward(new ExpReward(5910366, 5910366));
		AddReward(new ItemReward("expCard12", 2));
		AddReward(new ItemReward("Vis", 10000));

		AddDialogHook("TABLE73_SUB_ARTIFACT2", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE73_SUB_ARTIFACT2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You destroyed the cursed statue!");
		// Func/TABLE73_SUBQ1_COMPLETE;
		ZoneServer.Instance.World.FindNPC("TABLE73_SUB_ARTIFACT2")?.PlayEffectLocal(character.Connection, "F_explosion098_dark_blue", 1f, "BOT");
		await dialog.Msg("NPCAin/TABLE73_SUB_ARTIFACT2/DEAD/0");
		ZoneServer.Instance.World.FindNPC("TABLELAND73_SUBQ4_DEVICE")?.PlayEffectLocal(character.Connection, "F_explosion098_dark_blue", 1f, "BOT");
		await dialog.Msg("NPCAin/TABLELAND73_SUBQ4_DEVICE/DEAD/0");
		dialog.HideNPC("TABLE73_SUB_ARTIFACT2");
		dialog.HideNPC("TABLELAND73_SUBQ4_DEVICE");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

