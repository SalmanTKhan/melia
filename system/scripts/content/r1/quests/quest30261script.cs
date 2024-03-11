//--- Melia Script -----------------------------------------------------------
// Assassin Ebonypawn(6)
//--- Description -----------------------------------------------------------
// Quest to Find the traces of Ebonypawn in the repair shop.
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

[QuestScript(30261)]
public class Quest30261Script : QuestScript
{
	protected override void Load()
	{
		SetId(30261);
		SetName("Assassin Ebonypawn(6)");
		SetDescription("Find the traces of Ebonypawn in the repair shop");

		AddPrerequisite(new LevelPrerequisite(289));
		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_4_SQ_7"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 12138));

		AddDialogHook("CASTLE_20_4_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("CASTLE_20_4_SQ_8_succ");
		character.AddonMessage(AddonMessage.SHOW_QUEST_SEL_DLG, null, this.QuestId);
		await dialog.Msg("CASTLE_20_4_SQ_8_SUC01");
		await dialog.Msg("왕실의 사연에 대해 물어본다");
		await dialog.Msg("CASTLE_20_4_SQ_8_SUC02");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnStart(Character character, Quest quest)
	{
		character.AddonMessage(AddonMessage.NOTICE_Dm_Scroll, " Find the traces of Assassin Ebonypawn in the repair shop.");
	}
}

