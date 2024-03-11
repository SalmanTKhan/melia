//--- Melia Script -----------------------------------------------------------
// Sea Energy
//--- Description -----------------------------------------------------------
// Quest to Gather Sea Energy.
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

[QuestScript(80106)]
public class Quest80106Script : QuestScript
{
	protected override void Load()
	{
		SetId(80106);
		SetName("Sea Energy");
		SetDescription("Gather Sea Energy");

		AddPrerequisite(new LevelPrerequisite(226));
		AddPrerequisite(new CompletedPrerequisite("CORAL_35_2_SQ_7"));

		AddReward(new ExpReward(1623069, 1623069));
		AddReward(new ItemReward("expCard11", 1));
		AddReward(new ItemReward("Vis", 8136));

		AddDialogHook("CORAL_35_2_LUTAS_2", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_35_2_LUTAS_2", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("CORAL_35_2_SQ_8_succ");
		dialog.HideNPC("CORAL_35_2_TERRA_MAKING");
		await dialog.Msg("NPCAin/CORAL_35_2_LUTAS_2/bury/0");
		dialog.UnHideNPC("CORAL_35_2_CRYSTAL_TERRA");
		ZoneServer.Instance.World.FindNPC("CORAL_35_2_CRYSTAL_TERRA")?.PlayEffectLocal(character.Connection, "F_pattern015_green", 1f, "BOT");
		dialog.UnHideNPC("CORAL_35_2_SQ_TERRA_WALL");
		dialog.UnHideNPC("CORAL_35_2_TERRA_MINI");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.Msg("BalloonText/CORAL_35_2_SQ_8_start/8");
	}
}

